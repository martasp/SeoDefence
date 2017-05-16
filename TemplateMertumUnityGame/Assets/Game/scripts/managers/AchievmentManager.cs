using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AchievmentManager : MonoBehaviour {

    private int newKills = 0;

    public Text killcountText;
    public Text buildedTowersText;
    public Text playTimesText;
    public Text PlaneKillsText;
    public Text soldTowersText;
    public Text survivedEnemiesText;
    public Text splashedEnemiesText;
    public Text killedText;
    public Text moneyEarnedText;
    public Text moneySpentText;

    private int killcount = 22000;
    private int buildedTowers = 2000;
    private int playTimes = 50;
    private int PlaneKills = 500;
    private int soldTowers = 500;
    private int survivedEnemies = 2000;
    private int splashedEnemies = 5;
    private int killed = 100;
    private int moneyEarned = 50000;
    private int moneySpent = 50000;

    // Use this for initialization
    void Start () {
       // Display();
	}
    public bool checkKillcount ()
    {
        if (PlayerPrefs.GetInt("killcountCheck", 0) < 1)
            if (PlayerPrefs.GetInt("killcount", 0) >= killcount)
            {
                PlayerPrefs.SetInt("killcountCheck", 1);
                return true;
            }
        return false;
    }
    public bool checkBuildedTowers()
    {
        if (PlayerPrefs.GetInt("buildedTowersCheck", 0) < 1)
            if (PlayerPrefs.GetInt("buildedTowers", 0) >= buildedTowers)
            {
                PlayerPrefs.SetInt("buildedTowersCheck", 1);
                return true;
            }
        return false;
    }
    public bool checkPlayTimes()
    {
        if (PlayerPrefs.GetInt("playTimesCheck", 0) < 1)
            if (PlayerPrefs.GetInt("playTimes", 0) >= playTimes)
            {
                PlayerPrefs.SetInt("playTimesCheck", 1);
                return true;
            }
        return false;
    }
    public bool checkPlaneKills()
    {
        if (PlayerPrefs.GetInt("PlaneKillsCheck", 0) < 1)
            if (PlayerPrefs.GetInt("PlaneKills", 0) >= PlaneKills)
            {
                PlayerPrefs.SetInt("PlaneKillsCheck", 1);
                return true;
            }
        return false;
    }
    public bool checkSoldTowers()
    {
        if (PlayerPrefs.GetInt("soldTowersCheck", 0) < 1)
            if (PlayerPrefs.GetInt("soldTowers", 0) >= soldTowers)
            {
                PlayerPrefs.SetInt("soldTowersCheck", 1);
                return true;
            }
        return false;
    }
    public bool checkSurvivedEnemies()
    {
        if (PlayerPrefs.GetInt("survivedEnemiesCheck", 0) < 1)
            if (PlayerPrefs.GetInt("survivedEnemies", 0) >= survivedEnemies)
            {
                PlayerPrefs.SetInt("survivedEnemiesCheck", 1);
                return true;
            }
        return false;
    }
    public bool checkSplashedEnemies()
    {
        if (PlayerPrefs.GetInt("splashedEnemiesCheck", 0) < 1)
            if (PlayerPrefs.GetInt("splashedEnemies", 0) >= splashedEnemies)
            {
                PlayerPrefs.SetInt("splashedEnemiesCheck", 1);
                return true;
            }
        return false;
    }
    public bool checkKilled()
    {
        if (PlayerPrefs.GetInt("killedCheck", 0) < 1)
            if (newKills >= killed)
            {
                PlayerPrefs.SetInt("killedCheck", 1);
                return true;
            }
        return false;
    }
    public bool checkMoneyEarned()
    {
        if (PlayerPrefs.GetInt("moneyEarnedCheck", 0) < 1)
            if (PlayerPrefs.GetInt("moneyEarned", 0) >= moneyEarned)
            {
                PlayerPrefs.SetInt("moneyEarnedCheck", 1);
                return true;
            }
        return false;
    }
    public bool checkMoneySpent()
    {
        if (PlayerPrefs.GetInt("moneySpentCheck", 0) < 1)
            if (PlayerPrefs.GetInt("moneySpent", 0) >= moneySpent)
            {
                PlayerPrefs.SetInt("moneySpentCheck", 1);
                return true;
            }
        return false;
    }

    public void Display()
    {
        killcountText.text = PlayerPrefs.GetInt("killcount", 0).ToString();
        if (PlayerPrefs.GetInt("killcount", 0) < killcount) killcountText.text += " / " + killcount.ToString();
        buildedTowersText.text = PlayerPrefs.GetInt("buildedTowers", 0).ToString();
        if (PlayerPrefs.GetInt("buildedTowers", 0) < buildedTowers) buildedTowersText.text += " / " + buildedTowers.ToString();
        playTimesText.text = PlayerPrefs.GetInt("playTimes", 0).ToString();
        if (PlayerPrefs.GetInt("playTimes", 0) < playTimes) playTimesText.text += " / " + playTimes.ToString();
        PlaneKillsText.text = PlayerPrefs.GetInt("PlaneKills", 0).ToString();
        if (PlayerPrefs.GetInt("PlaneKills", 0) < PlaneKills) PlaneKillsText.text += " / " + PlaneKills.ToString();
        soldTowersText.text = PlayerPrefs.GetInt("soldTowers", 0).ToString();
        if (PlayerPrefs.GetInt("soldTowers", 0) < soldTowers) soldTowersText.text += " / " + soldTowers.ToString();
        survivedEnemiesText.text = PlayerPrefs.GetInt("survivedEnemies", 0).ToString();
        if (PlayerPrefs.GetInt("survivedEnemies", 0) < survivedEnemies) survivedEnemiesText.text += " / " + survivedEnemies.ToString();
        splashedEnemiesText.text = PlayerPrefs.GetInt("splashedEnemies", 0).ToString();
        if (PlayerPrefs.GetInt("splashedEnemies", 0) < splashedEnemies) splashedEnemiesText.text += " / " + splashedEnemies.ToString();
        killedText.text = PlayerPrefs.GetInt("killed", 0).ToString();
        if (PlayerPrefs.GetInt("killed", 0) < killed) killedText.text += " / " + killed.ToString();
        moneyEarnedText.text = PlayerPrefs.GetInt("moneyEarned", 0).ToString();
        if (PlayerPrefs.GetInt("moneyEarned", 0) < moneyEarned) moneyEarnedText.text += " / " + moneyEarned.ToString();
        moneySpentText.text = PlayerPrefs.GetInt("moneySpent", 0).ToString();
        if (PlayerPrefs.GetInt("moneySpent", 0) < moneySpent) moneySpentText.text += " / " + moneySpent.ToString();
    }
    public void resetAchievments ()
    {
        PlayerPrefs.SetInt("killcount", 0); //nuzudytu priesu kiekis
        PlayerPrefs.SetInt("buildedTowers", 0); //pastatytu boksteliu kiekis
        PlayerPrefs.SetInt("playTimes", 0); //number of time played
        PlayerPrefs.SetInt("PlaneKills", 0); //sunaikintu lektuvu kiekis
        PlayerPrefs.SetInt("soldTowers", 0); //parduotu boksteliu kiekis
        PlayerPrefs.SetInt("survivedEnemies", 0); //praejusiu visa kelia priesu kiekis
        PlayerPrefs.SetInt("splashedEnemies", 0); //didziausias kiekis priesas vienu suviu
        PlayerPrefs.SetInt("killed", 0); //daugiausiai per viena zaidima nuzudytu priesu kiekis
        PlayerPrefs.SetInt("moneyEarned", 0); //uzdirbti pinigai
        PlayerPrefs.SetInt("moneySpent", 0); //isleisti pinigai

        PlayerPrefs.SetInt("killcountCheck", 0); //nuzudytu priesu kiekis
        PlayerPrefs.SetInt("buildedTowersCheck", 0); //pastatytu boksteliu kiekis
        PlayerPrefs.SetInt("playTimesCheck", 0); //number of time played
        PlayerPrefs.SetInt("PlaneKillsCheck", 0); //sunaikintu lektuvu kiekis
        PlayerPrefs.SetInt("soldTowersCheck", 0); //parduotu boksteliu kiekis
        PlayerPrefs.SetInt("survivedEnemiesCheck", 0); //praejusiu visa kelia priesu kiekis
        PlayerPrefs.SetInt("splashedEnemiesCheck", 0); //didziausias kiekis priesas vienu suviu
        PlayerPrefs.SetInt("killedCheck", 0); //daugiausiai per viena zaidima nuzudytu priesu kiekis
        PlayerPrefs.SetInt("moneyEarnedCheck", 0); //uzdirbti pinigai
        PlayerPrefs.SetInt("moneySpentCheck", 0); //isleisti pinigai
    }
    public void addKillCount()
    {
        PlayerPrefs.SetInt("killcount", getKillCount() + 1);
        newKills++;
    }
    public void addTower()
    {
        PlayerPrefs.SetInt("buildedTowers", getTowerBuild() + 1);
    }
    public void addPlayTimes()
    {
        PlayerPrefs.SetInt("playTimes", getPlayTimes() + 1);
    }
    public void addPlaneKill()
    {
        PlayerPrefs.SetInt("PlaneKills", getPlaneKills() + 1);
    }
    public void addSoldTowers()
    {
        PlayerPrefs.SetInt("soldTowers", getTowersSold() + 1);
    }
    public void addAliveEnemies()
    {
        PlayerPrefs.SetInt("survivedEnemies", getSurvivals() + 1);
    }
    public void addSplashRAD(int newSplash)
    {
        if (newSplash > getSplashRAD())
            PlayerPrefs.SetInt("splashedEnemies", newSplash);
    }
    public void checkKilledIOG()
    {
        if (newKills > getKillsIOG())
            PlayerPrefs.SetInt("killed", newKills);
    }
    public void addMoneyEarned(int money)
    {
        PlayerPrefs.SetInt("moneyEarned", getMoneyEarned() + money);
    }
    public void addMoneySpent(int money)
    {
        PlayerPrefs.SetInt("moneySpent", getMoneySpent() + money);
    }

    public int getKillCount ()
    {
        return PlayerPrefs.GetInt("killcount", 0);
    }
    public int getTowerBuild()
    {
        return PlayerPrefs.GetInt("buildedTowers", 0);
    }
    public int getPlayTimes()
    {
        return PlayerPrefs.GetInt("playTimes", 0);
    }
    public int getPlaneKills()
    {
        return PlayerPrefs.GetInt("PlaneKills", 0);
    }
    public int getTowersSold()
    {
        return PlayerPrefs.GetInt("soldTowers", 0);
    }
    public int getSurvivals()
    {
        return PlayerPrefs.GetInt("survivedEnemies", 0);
    }
    public int getSplashRAD()
    {
        return PlayerPrefs.GetInt("splashedEnemies", 0);
    }
    public int getKillsIOG()
    {
        return PlayerPrefs.GetInt("killed", 0);
    }
    public int getMoneyEarned()
    {
        return PlayerPrefs.GetInt("moneyEarned", 0);
    }
    public int getMoneySpent()
    {
        return PlayerPrefs.GetInt("moneySpent", 0);
    }

}
