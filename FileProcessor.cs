using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ParallelPractice
{
    public static class FileProcessor
    {
        public static async Task<KeyValuePair<string, int>[]> CountSpacesInDirectoryFiles(string directoryPath, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(directoryPath);
            FileInfo[] files = dirInfo.GetFiles("*.*", searchOption);
            Task[] tasks = new Task[files.Length];
            KeyValuePair<string, int>[] result = new KeyValuePair<string, int>[files.Length];
            for (int i = 0; i < files.Length; i++)
            {
                var file = files[i];
                var k = i;
                var task = Task.Run(() =>
                {
                    result[k] = CountSpacesInFile(file.FullName);
                });
                tasks[i] = task;
            }
            await Task.WhenAll(tasks);
            return result;
        }

        public static KeyValuePair<string, int> CountSpacesInFile(string filePath)
        {
            using StreamReader sr = new StreamReader(filePath);
            int count = 0;
            while (sr.Peek() != -1)
            {
                char symbol = (char)sr.Read();
                if (char.IsWhiteSpace(symbol)) count++;
            }
            return new KeyValuePair<string, int>(filePath, count);
        }
    }
}
