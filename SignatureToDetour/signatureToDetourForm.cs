using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignatureToDetour
{
    public partial class signatureToDetourForm : Form
    {
        public class Signature
        {
            public string name { get; set; }
            public string signature { get; set; }
        }

        List<Signature> signatures;

        public signatureToDetourForm()
        {
            InitializeComponent();
            signatures = new List<Signature>();
        }

        private void MakeDetour_Click(object sender, EventArgs e)
        {
            outputTextbox.Text = "";

            List<string> detours = new List<string>();
            List<string> declarations = new List<string>();

            int counter = 0;

            foreach (Signature sig in signatures)
            {     
                string desired_name = sig.name;
                if (desired_name.Length == 0)
                { 
                    desired_name = "Unknown" + counter.ToString();
                    counter++;
                }

                string signature = sig.signature; //char __cdecl sub_1193D40(int a1, unsigned int a2, signed int *a3, _BYTE **a4, const char *a5)
                string out_detour = "";

                int pre_loc = signature.IndexOf('(');
                string pre_part = "";

                if (pre_loc >= 0)
                    pre_part = signature.Substring(0, pre_loc);
                else
                    pre_part = signature;

                int cdecl_loc = pre_part.IndexOf("__");
                string cdecl_part = "";

                if (cdecl_loc >= 0)
                    cdecl_part = pre_part.Substring(cdecl_loc, 7);

                int name_loc = pre_part.IndexOf("sub");
                string name = "";

                if (name_loc >= 0)
                    name = pre_part.Substring(name_loc, (pre_loc >= 0 ? pre_loc : pre_part.Length) - name_loc);

                int address_loc = name.IndexOf('_');
                string address = "";
                if (address_loc >= 0)
                    address = name.Substring(address_loc + 1);

                string arguments = "";
                if (pre_loc >= 0)
                    arguments = signature.Substring(pre_loc + 1, signature.Length - (pre_loc + 1) - 1);
                
                string[] arglist = arguments.Split(',');

                string return_type = "";

                if (cdecl_loc >= 0)
                    return_type = signature.Substring(0, cdecl_loc);
                else
                    return_type = signature.Substring(0, signature.IndexOf("sub"));

                return_type = return_type.Trim();

                out_detour = address;

                out_detour = "#define " + desired_name.ToUpper() + "_ADDRESS 0x" + address + Environment.NewLine; // Address of function to hook
                out_detour += return_type + "("; // Return type
                out_detour += cdecl_part + "* "; // Declaration, cdecl supported right now
                out_detour += "original" + desired_name + ")(";

                string last = arglist.Last();
                last = last.Trim();

                string argtypes = "";
                if (arglist.Length == 1 && arglist[0].Length == 0)                
                    out_detour += ");";                                    
                else
                {
                    foreach (string a in arglist)
                    {                        
                        int indx = -1;
                        bool has_dual_pointer = a.IndexOf("**") >= 0;
                        bool has_single_pointer = (a.IndexOf('*') >= 0 && !has_dual_pointer);

                        indx = has_dual_pointer ? a.IndexOf("**") + 2 : has_single_pointer ? a.IndexOf('*') + 1 : a.LastIndexOf(' ');
                        string type = a.Substring(0, indx == 0 ? a.Length : indx);

                        type = type.Trim();
                        if (a == last)
                            out_detour += type + ");";
                        else
                            out_detour += type + ", ";

                        if (a == last)
                            argtypes += type;
                        else
                            argtypes += type + ", ";
                    }
                }



                out_detour += Environment.NewLine;

                out_detour += return_type + " " + "hk" + desired_name + "(";
                if (arglist.Length == 1 && arglist[0].Length == 0)
                    out_detour += ")";
                else
                {
                    foreach (string a in arglist)
                    {
                        string tmp = a.Trim();
                        if (tmp == last)
                            out_detour += tmp + ")";
                        else
                            out_detour += tmp + ", ";
                    }
                }

                out_detour += Environment.NewLine + "{" + Environment.NewLine;

                out_detour += "     return original" + desired_name + "(";

                if (arglist.Length == 1 && arglist[0].Length == 0)
                    out_detour += ");";
                else
                {
                    foreach (string a in arglist)
                    {
                        string argname = a.Substring(a.Length - 2);

                        string tmp = a.Trim();
                        if (tmp == last)
                            out_detour += argname + ");";
                        else
                            out_detour += argname + ", ";
                    }
                }

                out_detour += Environment.NewLine + "}";

                out_detour += Environment.NewLine;
                out_detour += Environment.NewLine;

                if (cdecl_part.Length == 0)
                    cdecl_part = "__stdcall";

                string det = "original" + desired_name + " = (" + return_type + "(" + cdecl_part + "*)(" + argtypes + "))DetourFunction((PBYTE)" + desired_name.ToUpper() + "_ADDRESS, (PBYTE)hk" + desired_name + ");";

                det = det.Replace("_BYTE", "BYTE");
                out_detour = out_detour.Replace("_BYTE", "BYTE");                

                detours.Add(det);
                declarations.Add(out_detour);
            }

            outputTextbox.Text = string.Join(Environment.NewLine, declarations);
            outputTextbox.Text += string.Join(Environment.NewLine, detours);

        }

        private void addSignatureBtn_Click(object sender, EventArgs e)
        {
            Signature sig = new Signature();
            sig.name = functionNameTextBox.Text;
            sig.signature = functionSignatureTextBox.Text;

            signatures.Add(sig);

            signatureListBox.Items.Add(functionNameTextBox.Text + " : " + functionSignatureTextBox.Text);

            functionNameTextBox.Text = "";
            functionSignatureTextBox.Text = "";

        }

        private void functionSignatureTextBox_Enter(object sender, EventArgs e)
        {
            if (functionSignatureTextBox.Text == "Example: char sub_12345()")
                functionSignatureTextBox.Text = "";
        }
    }
}
