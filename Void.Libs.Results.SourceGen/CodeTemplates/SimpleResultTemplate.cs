// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Void.Libs.Results.SourceGen.CodeTemplates
{
    using Configuration;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\null\RiderProjects\Void.Libs\Void.Libs.Results.SourceGen\CodeTemplates\SimpleResultTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class SimpleResultTemplate : SimpleResultTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\n#nullable enable\r\n\r\nnamespace ");
            
            #line 6 "C:\Users\null\RiderProjects\Void.Libs\Void.Libs.Results.SourceGen\CodeTemplates\SimpleResultTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Settings.Namespace));
            
            #line default
            #line hidden
            this.Write(";\r\n\r\n// Required usings\r\nusing System.CodeDom.Compiler;\r\nusing Void.Libs.Results;\r\n\r\n/// <auto-generated>\r\n/// Source file was generated by Void.Libs.Results.SourceGen at ");
            
            #line 13 "C:\Users\null\RiderProjects\Void.Libs\Void.Libs.Results.SourceGen\CodeTemplates\SimpleResultTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DateTime.Now.ToString("f")));
            
            #line default
            #line hidden
            this.Write("<br/>\r\n/// Do not edit. Changes will be lost.\r\n/// </auto-generated>\r\n[GeneratedCode(\"Void.Libs.Results.SourceGen\", null)]\r\npublic class ");
            
            #line 17 "C:\Users\null\RiderProjects\Void.Libs\Void.Libs.Results.SourceGen\CodeTemplates\SimpleResultTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Settings.ClassName));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public bool Successful { get; set; }\r\n    public List<ReportedMessage> Warnings { get; set; } = new();\r\n    public List<ReportedMessage> Errors { get; set; } = new();\r\n\r\n    public static ");
            
            #line 23 "C:\Users\null\RiderProjects\Void.Libs\Void.Libs.Results.SourceGen\CodeTemplates\SimpleResultTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Settings.ClassName));
            
            #line default
            #line hidden
            this.Write(" New => new();\r\n    \r\n    public ");
            
            #line 25 "C:\Users\null\RiderProjects\Void.Libs\Void.Libs.Results.SourceGen\CodeTemplates\SimpleResultTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Settings.ClassName));
            
            #line default
            #line hidden
            this.Write(" WithWarning(string message, string? causedBy = null)\r\n    {\r\n        Warnings.Add(new ReportedMessage(message, causedBy));\r\n        return this;\r\n    }\r\n    \r\n    public ");
            
            #line 31 "C:\Users\null\RiderProjects\Void.Libs\Void.Libs.Results.SourceGen\CodeTemplates\SimpleResultTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Settings.ClassName));
            
            #line default
            #line hidden
            this.Write(" WithWarning(ReportedMessage warning)\r\n    {\r\n        Warnings.Add(warning);\r\n        return this;\r\n    }\r\n    \r\n    public ");
            
            #line 37 "C:\Users\null\RiderProjects\Void.Libs\Void.Libs.Results.SourceGen\CodeTemplates\SimpleResultTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Settings.ClassName));
            
            #line default
            #line hidden
            this.Write(" WithError(string message, string? causedBy = null)\r\n    {\r\n        Errors.Add(new ReportedMessage(message, causedBy));\r\n        return this;\r\n    }\r\n\r\n    public ");
            
            #line 43 "C:\Users\null\RiderProjects\Void.Libs\Void.Libs.Results.SourceGen\CodeTemplates\SimpleResultTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Settings.ClassName));
            
            #line default
            #line hidden
            this.Write(" WithError(ReportedMessage error)\r\n    {\r\n        Errors.Add(error);\r\n        return this;\r\n    }\r\n\r\n    public ");
            
            #line 49 "C:\Users\null\RiderProjects\Void.Libs\Void.Libs.Results.SourceGen\CodeTemplates\SimpleResultTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Settings.ClassName));
            
            #line default
            #line hidden
            this.Write(" WithException(Exception ex, string? message)\r\n    {\r\n        Errors.Add(new ReportedMessage(message ?? ex.Message, null, ex));\r\n        return this;\r\n    }\r\n}\r\n\r\n");
            
            #line 56 "C:\Users\null\RiderProjects\Void.Libs\Void.Libs.Results.SourceGen\CodeTemplates\SimpleResultTemplate.tt"

    if (Settings.IncludeDataVariant)
    {

            
            #line default
            #line hidden
            this.Write("/// <auto-generated>\r\n/// Source file was generated by Void.Libs.Results.SourceGen at ");
            
            #line 61 "C:\Users\null\RiderProjects\Void.Libs\Void.Libs.Results.SourceGen\CodeTemplates\SimpleResultTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DateTime.Now.ToString("f")));
            
            #line default
            #line hidden
            this.Write("<br/>\r\n/// Do not edit. Changes will be lost.\r\n/// </auto-generated>\r\n[GeneratedCode(\"Void.Libs.Results.SourceGen\", null)]\r\npublic class ");
            
            #line 65 "C:\Users\null\RiderProjects\Void.Libs\Void.Libs.Results.SourceGen\CodeTemplates\SimpleResultTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Settings.ClassName));
            
            #line default
            #line hidden
            this.Write("<TData> {\r\n    public bool Successful { get; set; }\r\n    public List<ReportedMessage> Warnings { get; set; } = new();\r\n    public List<ReportedMessage> Errors { get; set; } = new();\r\n    public TData? Data { get; set; }\r\n\r\n    public static ");
            
            #line 71 "C:\Users\null\RiderProjects\Void.Libs\Void.Libs.Results.SourceGen\CodeTemplates\SimpleResultTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Settings.ClassName));
            
            #line default
            #line hidden
            this.Write("<TData> New => new();\r\n    \r\n    public ");
            
            #line 73 "C:\Users\null\RiderProjects\Void.Libs\Void.Libs.Results.SourceGen\CodeTemplates\SimpleResultTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Settings.ClassName));
            
            #line default
            #line hidden
            this.Write("<TData> WithData(TData data) {\r\n        Data = data;\r\n        return this;\r\n    }\r\n\r\n    public ");
            
            #line 78 "C:\Users\null\RiderProjects\Void.Libs\Void.Libs.Results.SourceGen\CodeTemplates\SimpleResultTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Settings.ClassName));
            
            #line default
            #line hidden
            this.Write("<TData> WithWarning(string message, string? causedBy = null)\r\n    {\r\n        Warnings.Add(new ReportedMessage(message, causedBy));\r\n        return this;\r\n    }\r\n    \r\n    public ");
            
            #line 84 "C:\Users\null\RiderProjects\Void.Libs\Void.Libs.Results.SourceGen\CodeTemplates\SimpleResultTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Settings.ClassName));
            
            #line default
            #line hidden
            this.Write("<TData> WithWarning(ReportedMessage warning)\r\n    {\r\n        Warnings.Add(warning);\r\n        return this;\r\n    }\r\n    \r\n    public ");
            
            #line 90 "C:\Users\null\RiderProjects\Void.Libs\Void.Libs.Results.SourceGen\CodeTemplates\SimpleResultTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Settings.ClassName));
            
            #line default
            #line hidden
            this.Write("<TData> WithError(string message, string? causedBy = null)\r\n    {\r\n        Errors.Add(new ReportedMessage(message, causedBy));\r\n        return this;\r\n    }\r\n\r\n    public ");
            
            #line 96 "C:\Users\null\RiderProjects\Void.Libs\Void.Libs.Results.SourceGen\CodeTemplates\SimpleResultTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Settings.ClassName));
            
            #line default
            #line hidden
            this.Write("<TData> WithError(ReportedMessage error)\r\n    {\r\n        Errors.Add(error);\r\n        return this;\r\n    }\r\n\r\n    public ");
            
            #line 102 "C:\Users\null\RiderProjects\Void.Libs\Void.Libs.Results.SourceGen\CodeTemplates\SimpleResultTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Settings.ClassName));
            
            #line default
            #line hidden
            this.Write("<TData> WithException(Exception ex, string? message)\r\n    {\r\n        Errors.Add(new ReportedMessage(message ?? ex.Message, null, ex));\r\n        return this;\r\n    }\r\n}\r\n");
            
            #line 108 "C:\Users\null\RiderProjects\Void.Libs\Void.Libs.Results.SourceGen\CodeTemplates\SimpleResultTemplate.tt"

    }

            
            #line default
            #line hidden
            this.Write("\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 112 "C:\Users\null\RiderProjects\Void.Libs\Void.Libs.Results.SourceGen\CodeTemplates\SimpleResultTemplate.tt"

    public SimpleResultConfiguration Settings { get; set; }

        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public class SimpleResultTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
