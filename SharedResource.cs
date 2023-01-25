using CivilMasterData.Models.BIM360.Formulas;
using CivilMasterData.Models.Utilities;
using Microsoft.Extensions.Localization;

namespace CivilMasterData
{
    public class SharedResource : ISharedResource
    {
        private readonly IStringLocalizer<SharedResource> _localizer;

        public SharedResource(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
        }
        
        public string Message(MESSAGE_CODES errorCode, string notes = null)
        {
            int code = (int)errorCode;
            string value = _localizer["MSG_" + code.ToString("0000")];
            if (!string.IsNullOrEmpty(notes))
                value += "-" + notes;
            return value;
        }

        public Log GetLog(MESSAGE_CODES errorCode, string description = null, string notes = null)
        {
            int code = (int)errorCode;
            string value = _localizer["MSG_" + code.ToString("0000")];
            Log log = new Log(value, description, notes);
            return log;
        }
    }

    public interface ISharedResource
    {
        string Message(MESSAGE_CODES errorCode, string notes = null);
        Log GetLog(MESSAGE_CODES errorCode, string description = null, string notes = null);
    }
}
