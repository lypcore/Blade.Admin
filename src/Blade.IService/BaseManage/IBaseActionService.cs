using Blade.Entity;
using Blade.Entity.BaseManage;
using Blade.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blade.Service.BaseManage
{
    public interface IBaseActionService
    {
        Task<List<BaseAction>> GetDataListAsync(BaseActionsInputDTO input);
        Task<List<BaseActionDTO>> GetTreeDataListAsync(BaseActionsInputDTO input);
        Task<BaseAction> GetTheDataAsync(string id);
        Task AddDataAsync(ActionEditInputDTO input);
        Task UpdateDataAsync(ActionEditInputDTO input);
        Task DeleteDataAsync(List<string> ids);
    }

    [Map(typeof(BaseAction))]
    public class ActionEditInputDTO : BaseAction
    {
        public List<BaseAction> permissionList { get; set; } = new List<BaseAction>();
    }

    public class BaseActionsInputDTO
    {
        public string[] ActionIds { get; set; }
        public string parentId { get; set; }
        public ActionType[] types { get; set; }
        public bool selectable { get; set; }
        public bool checkEmptyChildren { get; set; }
    }

    public class BaseActionDTO : TreeModel
    {
        public ActionType Type { get; set; }
        public String Url { get; set; }
        public string path { get => Url; }
        public bool NeedAction { get; set; }
        public string TypeText { get => ((ActionType)Type).ToString(); }
        public string NeedActionText { get => NeedAction ? "是" : "否"; }
        public object children { get => Children; }
        public string title { get => Text; }
        public string value { get => Id; }
        public string key { get => Id; }
        public bool selectable { get; set; }
        [JsonIgnore]
        public string Icon { get; set; }
        public string icon { get => Icon; }
        public int Sort { get; set; }
        public List<string> PermissionValues { get; set; }
    }
}