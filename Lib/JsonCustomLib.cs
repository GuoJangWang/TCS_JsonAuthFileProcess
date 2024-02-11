using Model;
using Model.BaseObject;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Interface;
using System.Net.Http.Headers;
using Common;

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
    public class JsonCustomLib : ILibGeneralField, IDisposable
    {
        private bool disposedValue;

        private JObject NewJObj { get; set; }

        private JObject OldJObj { get; set; }
        private List<int> _UserRoles { get; set; }

        public JsonModifyCommandModel JsonModifyCommandModel { get; set; }

        private FileOperationLib _FileOperationLib { get; set; }

        public JsonCustomLib(List<JsonModifyCommandModel> commandModels)
        {
            this._FileOperationLib = new FileOperationLib(commandModels);
            ProcessInitial(commandModels);
            this._UserRoles = InitialUserRoles();
        }

        /// <summary>
        /// 檔案、電文皆預設多層
        /// </summary>
        /// <returns></returns>
        public ServiceResult ModifyDepositAccountsJsonByUserCommand()
        {
            var result = new ServiceResult();
            try
            {
                GetNewJObj();
                
                //todo 要改成輪循多個檔案
                if (NewJObj.ToString()!=OldJObj.ToString())
                {
                    _FileOperationLib.DocumentOverWriteProcess(NewJObj);
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 把要修改的檔案Load成jObj
        /// </summary>
        /// <param name="commandModel"></param>
        private void ProcessInitial(JsonModifyCommandModel commandModel)
        {
            try
            {
                JsonModifyCommandModel = commandModel;
                var target = _FileOperationLib.GetFileJsonObject().Data;

                OldJObj = target;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// jObj的權限修改操作
        /// </summary>
        /// <param name="jsonObject"></param>
        /// <param name="screenId"></param>
        /// <returns></returns>
        private ServiceResult GetNewJObj()
        {
            var result = new ServiceResult();
            try
            {
                NewJObj = new JObject(OldJObj);
                var targetNode = NewJObj.SelectToken($"$..[?(@.screenID == '{JsonModifyCommandModel.TransactionID}')]")["roles"];

                var targetRoleAdr = _UserRoles.IndexOf(JsonModifyCommandModel.TargetRole);

                targetNode[targetRoleAdr] = JsonModifyCommandModel.Auth.ToEnumIntVal<SystemEnum.JsonAuthType>();

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

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 處置受控狀態 (受控物件)
                }

                // TODO: 釋出非受控資源 (非受控物件) 並覆寫完成項
                // TODO: 將大型欄位設為 Null
                disposedValue = true;
            }
        }

        // // TODO: 僅有當 'Dispose(bool disposing)' 具有會釋出非受控資源的程式碼時，才覆寫完成項
        // ~JsonCustomLib()
        // {
        //     // 請勿變更此程式碼。請將清除程式碼放入 'Dispose(bool disposing)' 方法
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // 請勿變更此程式碼。請將清除程式碼放入 'Dispose(bool disposing)' 方法
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
