using System.Reflection;
using UnityEngine;

/// <summary>
/// Originally "UnityUtilities" from https://github.com/TobiasWehrum/unity-utilities
/// </summary>
namespace UniFramework.Utility.Editor
{
    /// <summary>
    /// Provides static helper methods for editor classes.
    /// </summary>
    public static class EditorHelper
    {
        /// <summary>
        /// Gets the tooltip of a field.
        /// </summary>
        /// <param name="field">The field to get the tooltip from.</param>
        /// <returns>The tooltip if set, else an empty string.</returns>
        public static string GetTooltip(FieldInfo field)
        {
            var attributes = (TooltipAttribute[])field.GetCustomAttributes(typeof(TooltipAttribute), true);
            return (attributes.Length > 0)
                        ? attributes[0].tooltip
                        : "";
        }
    }
}
