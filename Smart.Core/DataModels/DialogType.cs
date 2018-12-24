
namespace Smart.Core
{
    public enum DialogType
    {
        None = 0,
        Information = 1,
        Success = 2,
        Question = 3,
        Exclamation = 4,
        Warning = 5
    }

    public static class DialogTypeExtensions
    {
        /// <summary>
        /// Converts <see cref="DialogType"/> to a FontAwesome string
        /// </summary>
        /// <param name="dialogType">The type to convert</param>
        /// <returns></returns>
        public static string ToIcon(this DialogType dialogType)
        {
            //Return a FontAwesome string based on the DialogType
            switch (dialogType)
            {
                case DialogType.Exclamation: return "\uf5d6";
                case DialogType.Information: return "\uf2fd";
                case DialogType.Question: return "\uf625";
                case DialogType.Success: return "\uf134";
                case DialogType.Warning: return "\uf15a";

                //If none found, return null
                default: return null;
            }
        }
    }
}
