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
        public signatureToDetourForm()
        {
            InitializeComponent();
        }

        private void MakeDetour_Click(object sender, EventArgs e)
        {
            string desired_name = functionNameTextBox.Text;
            if (desired_name.Length == 0)
                desired_name = "Unk001";

            outputTextbox.Text = "";

            string signature = functionSignatureTextBox.Text; //char __cdecl sub_1193D40(int a1, unsigned int a2, signed int *a3, _BYTE **a4, const char *a5)
            string out_detour = "";

            int pre_loc = signature.IndexOf('(');
            string pre_part = ""; 

            if (pre_loc >= 0)
                pre_part = signature.Substring(0, pre_loc);

            int cdecl_loc = pre_part.IndexOf('_');
            string cdecl_part = "";

            if (cdecl_loc >= 0)
                cdecl_part = pre_part.Substring(cdecl_loc, 7);

            int name_loc = pre_part.IndexOf("sub");
            string name = "";

            if (name_loc >= 0)
                name = pre_part.Substring(name_loc, pre_loc - name_loc);

            int address_loc = name.IndexOf('_');
            string address = "";
            if (address_loc >= 0)
                address = name.Substring(address_loc + 1);

            string arguments = signature.Substring(pre_loc + 1, signature.Length - (pre_loc + 1) - 1);
            string[] arglist = arguments.Split(',');

            string return_type = signature.Substring(0, cdecl_loc - 1);
            out_detour = address;

            out_detour = "#define " + desired_name.ToUpper() + "_ADDRESS 0x" + address + Environment.NewLine; // Address of function to hook
            out_detour += return_type + "("; // Return type
            out_detour += cdecl_part + "* "; // Declaration, cdecl supported right now
            out_detour += "original" + desired_name + ")(";

            string last = arglist.Last();

            string argtypes = "";

            foreach (string a in arglist)
            {
                string type = a.Substring(0, a.Length - 2);
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


            out_detour += Environment.NewLine;

            out_detour += return_type + " " + "hk" + desired_name + "(";
            foreach (string a in arglist)
            {
                if (a == last)
                    out_detour += a + ")";
                else
                    out_detour += a + ", ";
            }

            out_detour += Environment.NewLine + "{" + Environment.NewLine;

            out_detour += "return original" + desired_name + "(";


            foreach (string a in arglist)
            {
                string argname = a.Substring(a.Length-2);

                if (a == last)
                    out_detour += argname + ");";
                else
                    out_detour += argname + ", ";
            }

            out_detour += Environment.NewLine + "}";

            out_detour += Environment.NewLine;
            out_detour += Environment.NewLine;

            out_detour += "original" + desired_name + " = (" + return_type + "(" + cdecl_part + "*)(" + argtypes + "))DetourFunction((PBYTE)UNK_ADDRESS, (PBYTE)hk" + desired_name + ");";

            out_detour = out_detour.Replace("_BYTE", "BYTE");

            outputTextbox.Text = out_detour;
        }
    }
}
