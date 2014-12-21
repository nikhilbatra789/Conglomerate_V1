using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.CodeDom;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;

namespace Conglomerate
{
    public partial class Execute : Form
    {
        public Execute()
        {
            InitializeComponent();

            string sourceTemplate =@"using System; 
                                     using System.Windows.Forms; 
                                     namespace Foo 
                                    { 
                                        public static class Bar 
                                        { 
                                           public static void Execute() 
                                           {
                                             @Placeholder
                                           }
                                        }
                                      }";
            string sourceCode = sourceTemplate.Replace("@Placeholder", "int i = 2; int j = 3; int result = i + j/0; MessageBox.Show(result.ToString());");
           
            //CodeSnippetCompileUnit snippetCompileUnit = new CodeSnippetCompileUnit(sourceCode);
            //using (CSharpCodeProvider provider =
            // new CSharpCodeProvider(new Dictionary<String, String> { { "CompilerVersion", "v3.5" } }))
            //{
            //    CompilerParameters parameters = new CompilerParameters();
            //    parameters.ReferencedAssemblies.Add("System.dll");
            //    parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            //    parameters.GenerateExecutable = false;
            //    parameters.GenerateInMemory = true;
            //    parameters.IncludeDebugInformation = false;

            //    CompilerResults results = provider.CompileAssemblyFromDom(parameters, snippetCompileUnit);

            //    if (!results.Errors.HasErrors)
            //    {
            //        Type type = results.CompiledAssembly.GetType("Foo.Bar");
            //        MethodInfo method = type.GetMethod("Execute");
            //        method.Invoke(null, new object[] { });
            //    }
            //    else
            //    {
            //        StringBuilder sb = new StringBuilder();
            //        foreach (CompilerError compilerError in results.Errors)
            //            sb.AppendFormat("Error in line {0}:\n\n{1}", compilerError.Line, compilerError.ErrorText);
            //        MessageBox.Show(sb.ToString(), "Compiler Error");
            //    }
            //}
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter =
               "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            dialog.InitialDirectory = "C:\\";
            dialog.Title = "Select a text file";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fname = dialog.FileName;
                string sourceCode= System.IO.File.ReadAllText(fname);
                CodeSnippetCompileUnit snippetCompileUnit = new CodeSnippetCompileUnit(sourceCode);
                using (CSharpCodeProvider provider =
                 new CSharpCodeProvider(new Dictionary<String, String> { { "CompilerVersion", "v3.5" } }))
                {
                    CompilerParameters parameters = new CompilerParameters();
                    parameters.ReferencedAssemblies.Add("System.dll");
                    parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
                    parameters.GenerateExecutable = false;
                    parameters.GenerateInMemory = true;
                    parameters.IncludeDebugInformation = false;

                    CompilerResults results = provider.CompileAssemblyFromDom(parameters, snippetCompileUnit);

                    if (!results.Errors.HasErrors)
                    {
                        Type type = results.CompiledAssembly.GetType("Foo.Bar");
                        MethodInfo method = type.GetMethod("Execute");
                        method.Invoke(null, new object[] { });
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (CompilerError compilerError in results.Errors)
                            sb.AppendFormat("Error in line {0}:\n\n{1}", compilerError.Line, compilerError.ErrorText);
                        MessageBox.Show(sb.ToString(), "Compiler Error");
                    }
                }   
            }
        }
    }
}
