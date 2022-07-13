using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

namespace Projeto_ApontamentoHoras
{
    [FormAttribute("UDO_FT_RSD_APHR")]
    class RSD_APHR : UDOFormBase
    {
        public RSD_APHR()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("20_U_E").Specific));
            this.EditText0.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.EditText0_ChooseFromListAfter);
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("0_U_G").Specific));
            this.Matrix0.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.Matrix0_ChooseFromListAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.EditText EditText0;

        private void EditText0_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.SBOChooseFromListEventArg pValChoose = (SAPbouiCOM.SBOChooseFromListEventArg)pVal;
            if(pValChoose.SelectedObjects != null)
            {
                string empID = pValChoose.SelectedObjects.GetValue("empID", 0).ToString();
                string firstName = pValChoose.SelectedObjects.GetValue("firstName", 0).ToString();
                this.UIAPIRawForm.DataSources.DBDataSources.Item("@RSD_APHR").SetValue("U_Func", 0, empID);
                this.UIAPIRawForm.DataSources.DBDataSources.Item("@RSD_APHR").SetValue("U_Nome", 0, firstName);
            }
        }

        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.Matrix Matrix0;

        private void Matrix0_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.SBOChooseFromListEventArg pValChoose = (SAPbouiCOM.SBOChooseFromListEventArg)pVal;
            if (pValChoose.SelectedObjects != null)
            {
                string CardCode = pValChoose.SelectedObjects.GetValue("CardCode", 0).ToString();
                string CardName = pValChoose.SelectedObjects.GetValue("CardName", 0).ToString();

                this.UIAPIRawForm.DataSources.DBDataSources.Item("@RSD_APHRL").SetValue("U_Client", pValChoose.Row, CardCode);
                this.UIAPIRawForm.DataSources.DBDataSources.Item("@RSD_APHRL").SetValue("U_NomeCl", pValChoose.Row, CardName);

                Matrix0.LoadFromDataSource();
            }
        }
    }
}
