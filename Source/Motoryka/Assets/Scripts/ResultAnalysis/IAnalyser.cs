using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using LineManagement;

public interface IAnalyser {
	bool IsFinished(ILine generatedLine, ILine userLine);
}