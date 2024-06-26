﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Common;
using Lib;
using Model;

namespace JsonAuthFileProcess
{
    internal class Program
    {
        public static string LogPath { get; set; } = ConfigurationManager.AppSettings["LogPath"];

        public static JsonCustomLib JCustomLib { get; set; }

        static async Task Main(string[] args)
        {
            try
            {
                while (true)
                {
                    // 獲取用戶輸入
                    JsonModifyCommandModel userInput = GetJsonModifyCommand();

                    JCustomLib = new JsonCustomLib(userInput);

                    // 處理用戶輸入
                    await ProcessJsonModifyAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                WriteExceptionToFile(ex.ToString());
            }
        }

        private static JsonModifyCommandModel GetJsonModifyCommand()
        {
            var result = new JsonModifyCommandModel();
            try
            {
                Console.WriteLine("請輸入指令(逗號分割)\r\n(<交易代號>,<啟用或停用(Y/N)>)");
                var userInput = Console.ReadLine();

                //if (userInput == string.Empty)
                //{
                //    return result;
                //}

                result.ScreenID = userInput.Split(',')[0]==string.Empty? "CustomerInfo/062000": userInput.Split(',')[0];

                string authCommand = userInput.Split(',')[1];

                switch (authCommand)
                {
                    case "Y":
                        result.Auth = SystemEnum.JsonAuthType.able;
                        break;
                    case "N":
                    default:
                        result.Auth = SystemEnum.JsonAuthType.disable;
                        break;
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static void WriteExceptionToFile(string exceptionDetails)
        {
            try
            {
                var time = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                var filePath = Path.Combine(LogPath, time + ".txt");

                File.WriteAllText(filePath, exceptionDetails);
            }
            catch (Exception)
            {
                // 如果在寫入檔案時發生錯誤，可以在這裡處理
                Console.WriteLine("Failed to write exception details to the file.");
            }
        }
        private static async Task ProcessJsonModifyAsync()
        {
            try
            {
                JCustomLib.ModifyDepositAccountsJsonByUserCommand();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
