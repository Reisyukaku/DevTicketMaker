using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DevTicketMaker {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            commkeyTypeCombo.SelectedIndex = 0;
        }

        [DllImport("MakeTicket.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BuiltTicketData(byte[] titleID, byte[] tikID, byte[] encKey, byte[] eccPubKey, ushort version, byte[] contIndex);

        [DllImport("MakeTicket.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint BuildCetk(string fileOut, byte[] tikData, byte[] sig, byte[] chainSig);
        

        private void sanitizeInput() {
            if (Int32.Parse(verInput.Text) > 65535) verInput.Text = 65535.ToString();
            tidInput.Text = Regex.Replace(tidInput.Text, @"\s+", "");
            keyInput.Text = Regex.Replace(keyInput.Text, @"\s+", "");
        }

        private static byte[] StringToByteArray(string hex) {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        private byte[] getCommonKey() {
            byte[] key = null;
            switch (commkeyTypeCombo.SelectedIndex) {
                case 0:
                    key = Properties.Resources.CommonKey_eshop;
                    break;
                case 1:
                    key = Properties.Resources.CommonKey_system;
                    break;
            }
            return key;
        }

        private void genButton_Click(object sender, EventArgs e) {
            //Sanitize
            sanitizeInput();

            //Get given info
            byte[] tid = StringToByteArray(tidInput.Text);
            byte[] titleKey = StringToByteArray(keyInput.Text);
            ushort version = UInt16.Parse(verInput.Text);

            //Derive rest of info
            byte[] tikData = new byte[0x210];
            byte[] tikID = new byte[8];
            byte[] enc_key = Crypto.EncryptTitleKey(getCommonKey(), titleKey, tid);
            Marshal.Copy(BuiltTicketData(tid, tikID, enc_key, new byte[0x3C]/*ECC key*/, version, new byte[0xAC]/*Cont Index*/), tikData, 0, 0x210);
            var signature = new byte[] { 0x00, 0x01, 0x00, 0x04}.Concat(Crypto.RsaSign(tikData)).Concat(new byte[0x3C]).ToArray();

            //Generate
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK) {
                BuildCetk(sfd.FileName, tikData, signature, Properties.Resources.ChainSig);
                MessageBox.Show("Success!");
            }
        }
    }
}
