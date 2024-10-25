using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FILE_MANAGER.Helper
{
    public static class FileHelper
    {
        public static async Task<T> ReadFileAsync<T>(string path, Encoding encoding = null) where T : class
        {
            try
            {
                if (string.IsNullOrEmpty(path))
                    throw new ArgumentNullException(path);

                string str;
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var sr = encoding == null ? new StreamReader(fs) : new StreamReader(fs, encoding))
                    {
                        str = await sr.ReadToEndAsync();
                    }
                }

                return JsonConvert.DeserializeObject<T>(str);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
