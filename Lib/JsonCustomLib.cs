using Model;
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
    public class JsonCustomLib
    {
        public JsonCustomLib()
        {
            
        }

        public ServiceResult ModifyDepositAccountsJsonByUserCommand(JsonModifyCommandModel commandModel)
        {
            var result = new ServiceResult();
            try
            {
                var target = new DepositAccounts();

                var jsonItem = target.JsonObject;

                string screenIdToFind = commandModel.screenID;
                int[] roles = GetRolesByScreenId(jsonItem, screenIdToFind);

                if (roles != null)
                {
                    Console.WriteLine($"Roles for screenID {screenIdToFind}: {string.Join(", ", roles)}");
                }
                else
                {
                    Console.WriteLine($"No roles found for screenID {screenIdToFind}");
                }

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


    }
}
