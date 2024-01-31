﻿using Model;
using Model.BaseObject;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    /// <summary>
    /// 目前看起來V3是列出該Role所有可用的功能
    /// 建議V4可以比照，然後新架構就兩個動作
    /// 1. 把有權限的全部On起來
    /// 2. 排除有權限的，其他全部關掉
    /// 
    /// Roles直接找最大值
    /// 
    /// ex  Role99可用的只有062000
    /// 
    /// 然後Role有以下
    /// 
    /// "roles": [
    //  1,
    //  2,
    //  3,
    //  4,
    //  5,
    //  6,
    //  7,
    //  8,
    //  9,
    //  10,
    //  11,
    //  12,
    //  98,
    //  99,
    //  201,
    //  202,
    //  203,
    //  204,
    //  205,
    //  206,
    //  207,
    //  208,
    //  209,
    //  210,
    //  211,
    //  212,
    //  298,
    //  299,
    //  215,
    //  216
    //]
    /// 
    /// 那就"screenID": "CustomerInfo/062000"的Role設定抓出來
    /// 
    /// 把第12個位址 on成0，其餘不動(因為是其他Role的設定)
    /// 
    /// 然後所有檔案都比照辦理
    /// 只是沒權限的是位址13改成17
    /// 
    /// </summary>
    public class JsonCustomLib
    {
        private List<int> _UserRoles { get; set; }

        private JObject _JsonItem { get; set; }

        private JsonModifyCommandModel _JsonModifyCommandModel { get; set; }

        private FileOperationLib _FileOperationLib { get; set; }

        public JsonCustomLib()
        {
            this._UserRoles = InitialUserRoles();
            this._FileOperationLib = new FileOperationLib();
        }

        public ServiceResult ModifyDepositAccountsJsonByUserCommand(JsonModifyCommandModel commandModel)
        {
            var result = new ServiceResult();
            try
            {
                ProcessInitial(commandModel);

                SetRoleFalseByScreenId(_JsonItem, _JsonModifyCommandModel.ScreenID);

                _FileOperationLib.DocumentOverWriteProcess();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ProcessInitial(JsonModifyCommandModel commandModel)
        {
            try
            {
                _JsonModifyCommandModel = commandModel;
                var target = _FileOperationLib.GetFileJsonObject(_JsonModifyCommandModel.TargetFile).Data;

                _JsonItem = target;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private ServiceResult SetRoleFalseByScreenId(JObject jsonObject, string screenId)
        {
            var result = new ServiceResult();
            try
            {
                var targetNode = jsonObject.SelectToken($"$..[?(@.screenID == '{screenId}')]")["roles"];

                var targetRoleAdr = _UserRoles.IndexOf(_JsonModifyCommandModel.TargetRole);

                targetNode[targetRoleAdr] = 17;

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }



        private int[] GetRolesByScreenId(JObject jsonObject, string screenId)
        {
            try
            {
                JToken targetNode = jsonObject.SelectToken($"$..[?(@.screenID == '{screenId}')]");

                if (targetNode != null)
                {
                    // Found the node with the specified screenID
                    return targetNode["roles"].ToObject<int[]>();
                }
                else
                {
                    // ScreenID not found
                    return null;
                }
            }
            catch (JsonReaderException)
            {
                // Handle JSON parsing errors
                Console.WriteLine("Error parsing JSON");
                return null;
            }
        }

        /// <summary>
        /// TODO改成指定的檔案
        /// </summary>
        /// <returns></returns>
        private List<int> InitialUserRoles()
        {
            var result = new List<int>();
            try
            {
                var mainMenuItem = new MainMenu();
                var jsonObject = mainMenuItem.JsonObject;
                var targetItem = jsonObject["roles"];

                if (targetItem != null)
                {
                    result = targetItem.ToObject<List<int>>();
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
