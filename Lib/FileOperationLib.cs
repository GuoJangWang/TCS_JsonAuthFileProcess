using Lib.Interface;
using Model;
using Model.BaseObject;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class FileOperationLib : ILibGeneralField
    {
        public string DeployWorkingRoot { get; set; }

        public JsonModifyCommandModel JsonModifyCommandModel { get; set; }

        public FileOperationLib(JsonModifyCommandModel commandModel)
        {
            this.DeployWorkingRoot = ConfigurationManager.AppSettings["DeployWorkingRoot"];
            this.JsonModifyCommandModel = commandModel;
        }

        /// <summary>
        /// TODO實作
        /// </summary>
        /// <returns></returns>
        public ServiceResult DocumentOverWriteProcess()
        {
            var result = new ServiceResult();
            try
            {
                // 讀取文件內容
                string fileContent = File.ReadAllText(DeployWorkingRoot);

                // 在這裡對文件內容進行修改
                // 例如，將文字添加到文件末尾
                fileContent += "\nThis is the appended text.";

                // 將修改後的內容寫回文件
                File.WriteAllText(filePath, fileContent);

                Console.WriteLine("File modified successfully.");


                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ServiceResult<JObject> GetFileJsonObject(string targetFileName)
        {
            var result = new ServiceResult<JObject>();
            try
            {


                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string FindFile(string targetFileName)
        {
            string[] files = null;
            string[] subdirectories = null;

            // 檢查目錄是否存在
            if (!Directory.Exists(DeployWorkingRoot))
                return null;

            try
            {
                // 檢查當前目錄中是否有目標文件
                files = Directory.GetFiles(DeployWorkingRoot, targetFileName);
                if (files.Length > 0)
                    return files[0]; // 如果找到文件，返回文件路徑

                // 如果沒有找到目標文件，遞歸搜索子目錄
                subdirectories = Directory.GetDirectories(DeployWorkingRoot);
                foreach (string subdir in subdirectories)
                {
                    string foundPath = FindFile(subdir, targetFileName);
                    if (foundPath != null)
                        return foundPath; // 如果在子目錄中找到文件，返回文件路徑
                }
            }
            catch (Exception)
            {
                // 可以在此處處理任何錯誤
                // 如果有必要，你可以將這些錯誤記錄到日誌中
            }

            return null; // 如果未找到目標文件，返回null
        }

    }
}
