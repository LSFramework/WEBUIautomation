using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBPages.MyPCPages.DesignLoadTest
{
    public enum WorkloadMode
    {

        [Description("ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_imgBtnSimpleByLT")]
        SimpleByLT,

        [Description("ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_chkSimpleByLTByNumber")]
        SimpleByLTByNumber,
        
        [Description("ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_chkSimpleByLTByPrecentage")]
        SimpleByLTByPrecentage,
        
        [Description("ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_imgBtnSimpleByGroup")]
        SimpleByGroup,
        
        [Description("ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_imgBtnComplexByLT")]
        ComplexByLT,

        [Description("ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_chkComplexByLTByNumber")]
        ComplexByLTByNumber,

        [Description("ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_chkComplexByLTByPrecentage")]
        ComplexByLTByPrecentage,

        [Description("ctl00_PageContent_WorkloadTypeDialog_C_WorkloadCntrl_imgBtnComplexByGroup")]
        ComplexByGroup
    }
}
