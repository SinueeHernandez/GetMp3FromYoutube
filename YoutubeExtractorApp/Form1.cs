using NAudio.Lame;
using NAudio.MediaFoundation;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExtractor;

namespace YoutubeExtractorApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Our test youtube link
            //list.Items.Add("https://www.youtube.com/watch?v=-befR4wHsjQ&index=1&list=PLn07dXvOHuupuzoM92qfw4Zf0tis-8vFr");
            progressFile.Value = 0;
            progressFile.Maximum = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progress.Value = 0;
            progress.Maximum = list.Items.Count;
            progress.Update();
            foreach (var item in list.Items)
            {
                /*
                 * Get the available video formats.
                 * We'll work with them in the video and audio download examples.
                 */
                IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(item.ToString(), false);
                string fileName= "";
                console.Text = "Procesing " + progress.Value+1 + " of " + progress.Maximum+ ": " + item;
                try
                {
                    DownloadAudio(videoInfos, out fileName);
                    //DownloadVideo(videoInfos, out fileName);
                }
                catch (Exception ex)
                {
                    console.Text = fileName + ": " + ex.Message;
                }
                progress.Value++;
                progress.Update();
            }

        }


        private  void DownloadAudio(IEnumerable<VideoInfo> videoInfos, out string fileName)
        {
            /*
             * We want the first extractable video with the highest audio quality.
             */
            VideoInfo video = videoInfos
                .Where(info => info.CanExtractAudio)
                .OrderByDescending(info => info.AudioBitrate)
                .FirstOrDefault();

            if (video == null)
            {
                //throw new Exception("Can not extract audio");
                DownloadVideo(videoInfos, out fileName);
                AlternativeAudioExtraction(fileName);
                return;
            }

            /*
             * If the video has a decrypted signature, decipher it
             */
            if (video.RequiresDecryption)
            {
                DownloadUrlResolver.DecryptDownloadUrl(video);
            }

            /*
             * Create the audio downloader.
             * The first argument is the video where the audio should be extracted from.
             * The second argument is the path to save the audio file.
             */

            fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                RemoveIllegalPathCharacters(video.Title) + video.AudioExtension);
            var audioDownloader = new AudioDownloader(video, fileName);

            // Register the progress events. We treat the download progress as 85% of the progress
            // and the extraction progress only as 15% of the progress, because the download will
            // take much longer than the audio extraction.
            audioDownloader.DownloadProgressChanged += (sender, args) => Console.WriteLine(args.ProgressPercentage * 0.85);
            audioDownloader.AudioExtractionProgressChanged += (sender, args) => Console.WriteLine(85 + args.ProgressPercentage * 0.15);

            /*
             * Execute the audio downloader.
             * For GUI applications note, that this method runs synchronously.
             */
            audioDownloader.Execute();
        }

        private void DownloadVideo(IEnumerable<VideoInfo> videoInfos, out string fileName)
        {
            progressFile.Value = 0;
            /*
             * Select the first .mp4 video with 360p resolution
             */
            VideoInfo video = videoInfos
                .FirstOrDefault(info => info.VideoType == VideoType.Mp4 && info.Resolution == 360);

            /*
             * If the video has a decrypted signature, decipher it
             */
            if (video.RequiresDecryption)
            {
                DownloadUrlResolver.DecryptDownloadUrl(video);
            }

            /*
             * Create the video downloader.
             * The first argument is the video to download.
             * The second argument is the path to save the video file.
             */
            fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                RemoveIllegalPathCharacters(video.Title) + video.VideoExtension);
            label1.Text = fileName;
            var videoDownloader = new VideoDownloader(video, fileName);

            // Register the ProgressChanged event and print the current progress
            //videoDownloader.DownloadProgressChanged += (sender, args) => Console.WriteLine(args.ProgressPercentage);
            videoDownloader.DownloadProgressChanged += (sender, args) => progressFile.Value = (int)args.ProgressPercentage;
            progressFile.Update();

            /*
             * Execute the video downloader.
             * For GUI applications note, that this method runs synchronously.
             */
            videoDownloader.Execute();
        }


        private  string RemoveIllegalPathCharacters(string path)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            var r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            return r.Replace(path, "");
        }

        public  void AlternativeAudioExtraction(string path)
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);
            using (var reader = new MediaFoundationReader(path))
            {


                var outFile = Path.Combine(fileInfo.DirectoryName, fileInfo.Name.Replace(fileInfo.Extension, ".wav"));
                WaveFileWriter.CreateWaveFile(outFile, reader);
                using (var waveReader = new WaveFileReader(outFile))
                {
                    using (var wtr = new LameMP3FileWriter(outFile.Replace(".wav", ".mp3"), waveReader.WaveFormat, 128))
                    {
                        waveReader.CopyTo(wtr);
                        wtr.Close();
                        //MediaFoundationEncoder.EncodeToMp3(waveReader, outFile.Replace(".wav", ".mp3"));                    
                    }
                }
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            list.Items.Add(Url.Text);
            Url.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            list.Items.Remove(list.Items[list.SelectedIndex]);
        }
    }
}
