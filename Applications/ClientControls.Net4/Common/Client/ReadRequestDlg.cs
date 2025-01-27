/* ========================================================================
 * Copyright (c) 2005-2020 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 * 
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Opc.Ua;
using Opc.Ua.Client;

namespace Opc.Ua.Client.Controls
{
    /// <summary>
    /// Allows the user to edit and issue read requests.
    /// </summary>
    public partial class ReadRequestDlg : Form, ISessionForm
    {
        #region Constructors
        /// <summary>
        /// Creates an empty form.
        /// </summary>
        public ReadRequestDlg()
        {
            InitializeComponent();
            this.Icon = ClientUtils.GetAppIcon();
        }
        #endregion
        
        #region Private Fields
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Changes the session used for the read request.
        /// </summary>
        public void ChangeSession(ISession session)
        {
            ReadRequestCTRL.ChangeSession(session);
        }

        /// <summary>
        /// Adds the nodes to the read request.
        /// </summary>
        public void AddNodes(params ReadValueId[] nodesToRead)
        {
            ReadRequestCTRL.AddNodes(nodesToRead);
        }
        #endregion

        #region Private Methods
        #endregion

        #region Event Handlers
        private void ReadBTN_Click(object sender, EventArgs e)
        {
            try
            {
                ReadRequestCTRL.Read();
                BackBTN.Visible = true;
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        private void BackBTN_Click(object sender, EventArgs e)
        {
            try
            {
                ReadRequestCTRL.Back();
                BackBTN.Visible = false;
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        private void CloseBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Modal)
                {
                    DialogResult = DialogResult.Cancel;
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }
        #endregion
    }
}
