using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class FSMTransition
{
    public FSMDecision Decision;
    public string TrueState;
    public string FalseState;
}

