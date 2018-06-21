using System.IO;
using UnityEngine;
public  class ConstructCardDesc : CardDesc{
    public int hp;
    
    public int movesPerTurn;

    public AOEtype targetAOEtype;
    public int numOfTargets;
    public int turnsToBuild;


    public override CardDesc createInstance(string jsonString){
        return JsonUtility.FromJson<ConstructCardDesc>(jsonString);
    }
    
    public static void saveInstance(){

        ConstructCardDesc desc = 
        new ConstructCardDesc {
            id = 0,
            name = "sample",
            description = "this is a sample card",
            type = CardType.CONSTRUCT,
            rarity = Rarity.COMMON,
            collectible = true,
            set = CardSet.BASIC,
            hp = 10,
            movesPerTurn = 1,
            targetAOEtype = AOEtype.LINEAR,
            numOfTargets = 1,
            turnsToBuild = 2
        };
        string json = UnityEngine.JsonUtility.ToJson(desc,prettyPrint:true);

        File.WriteAllText(@"example_card.json",json);
    }
}