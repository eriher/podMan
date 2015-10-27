using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace PodcastBeta
{
    class PodMan
    {
        private int currentIndex;
        private static PodMan instance;
        public FlowLayoutPanel PlayerContainer { get; set; }
        public HashSet<Podcast> SubscribedPods { get; set; }
        public List<Podcast> playlist { get; set; }

        private PodMan() {
            playlist = new List<Podcast>();
            SubscribedPods = ReadFromJsonFile<HashSet<Podcast>>("subs");
            currentIndex = 0;
        }
        public static PodMan Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PodMan();
                }
                return instance;
            }
        }

        public static T _download_serialized_json_data<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }
        public Podcast getPlaying()
        {
            return playlist[currentIndex];
        }
        public void startMediaPlay(int index)
        {
            currentIndex = index;
            ((PlayerContainer.Controls["groupBox2"] as GroupBox).Controls["mediaPlayer"] as AxWMPLib.AxWindowsMediaPlayer).URL = playlist[index].recent_episodes[0].audio_url;
        }
        public void updatePlayingInfo()
        {
            foreach (Podcast p in playlist)
                if (p.recent_episodes[0].audio_url == ((PlayerContainer.Controls["groupBox2"] as GroupBox).Controls["mediaPlayer"] as AxWMPLib.AxWindowsMediaPlayer).currentMedia.sourceURL) {
                    
                    var epInfo = PlayerContainer.Controls["groupBox1"] as GroupBox;
                    (epInfo.Controls["playingPic"] as PictureBox).ImageLocation = p.image_url;
                    (epInfo.Controls["playingPic"] as PictureBox).LoadAsync(p.image_url);
                    (epInfo.Controls["playingPic"] as PictureBox).Tag = p;
                    (epInfo.Controls["playingPod"] as TextBox).Text = p.title;
                    (epInfo.Controls["playingEp"] as TextBox).Text = p.recent_episodes[0].title;
                }
        }
        public void addToPlaylist(Podcast pod)
        {
            playlist.Add(pod);
            ((PlayerContainer.Controls["groupBox2"] as GroupBox).Controls["mediaPlayer"] as AxWMPLib.AxWindowsMediaPlayer).currentPlaylist.appendItem(
                ((PlayerContainer.Controls["groupBox2"] as GroupBox).Controls["mediaPlayer"] as AxWMPLib.AxWindowsMediaPlayer).newMedia(pod.recent_episodes[0].audio_url));
            ((PlayerContainer.Controls["groupBox2"] as GroupBox).Controls["playlist"] as DataGridView).Rows.Add(pod.recent_episodes[0].title);
            if (playlist.Count == 1)
                startMediaPlay(0);
        }
        internal void UnSubscribe(Podcast pod)
        {
            SubscribedPods.Remove(pod);
            saveSubs();
        }

        internal void Subscribe(Podcast pod)
        {
            pod.recent_episodes = null;
            SubscribedPods.Add(pod);
            saveSubs();
        }

        public void saveSubs()
        {
            WriteToJsonFile<HashSet<Podcast>>("subs",SubscribedPods,false);
        }
        /// <summary>
        /// Writes the given object instance to a Json file.
        /// <para>Object type must have a parameterless constructor.</para>
        /// <para>Only Public properties and variables will be written to the file. These can be any type though, even other classes.</para>
        /// <para>If there are public properties/variables that you do not want written to the file, decorate them with the [JsonIgnore] attribute.</para>
        /// </summary>
        /// <typeparam name="T">The type of object being written to the file.</typeparam>
        /// <param name="filePath">The file path to write the object instance to.</param>
        /// <param name="objectToWrite">The object instance to write to the file.</param>
        /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
        public static void WriteToJsonFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
        {
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite);
                writer = new StreamWriter(filePath, append);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        /// <summary>
        /// Reads an object instance from an Json file.
        /// <para>Object type must have a parameterless constructor.</para>
        /// </summary>
        /// <typeparam name="T">The type of object to read from the file.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the Json file.</returns>
        public static T ReadFromJsonFile<T>(string filePath) where T : new()
        {
            TextReader reader = null;
            try
            {
                reader = new StreamReader(filePath);
                var fileContents = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(fileContents);
            }
            catch(FileNotFoundException)
            {
                WriteToJsonFile<T>("subs", new T(), false);
                return ReadFromJsonFile<T>(filePath);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}
