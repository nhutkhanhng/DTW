using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;

	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}

	public GameObject buildEffect;
	public GameObject sellEffect;

	private TurretBlueprint turretToBuild;
	private IPlacementArea selectedNode;

    private bool canBuild;
	public bool CanBuild { get { return canBuild = ((turretToBuild != null)
                /* && isBuildPath.instance.checkPath()*/); }
                                set { canBuild = value; } }
	public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

	public void SelectNode (IPlacementArea node)
	{
		if (selectedNode == node)
		{
			DeselectNode();
			return;
		}

        
        selectedNode = node;
		turretToBuild = null;
	}

	public void DeselectNode()
	{
		selectedNode = null;
	}

	public void SelectTurretToBuild (TurretBlueprint turret)
	{
		turretToBuild = turret;
		DeselectNode();
	}

	public TurretBlueprint GetTurretToBuild ()
	{
		return turretToBuild;
	}

}
