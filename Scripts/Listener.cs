using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Listener  {
    Dictionary<string, float> valueDifference; //Stores percent difference since last value
    Dictionary<string, int> reoccuringMessages;
    List<string> eventsToAnnounce;
    Dictionary<Globals.product, int> profit;
    enum mood { dire, bad, okay, good, great }

    public Listener()
    {
        profit = new Dictionary<Globals.product, int>();
        valueDifference = new Dictionary<string, float>();
        eventsToAnnounce = new List<string>();
        reoccuringMessages = new Dictionary<string, int>();
    }

    public void RecordString(string stringToRec)
    {
		Debug.Log ("In Listener, recording string " + stringToRec);
        eventsToAnnounce.Add(stringToRec);
    }

    public void RecordStringWithCountNumber(string stringToRec)
    {
        if (reoccuringMessages.ContainsKey(stringToRec))
            reoccuringMessages[stringToRec]++;
        else
            reoccuringMessages.Add(stringToRec,1);
    }

    public void TallyIncomingGoods(Globals.product prod,int amt)
    {
        if (profit.ContainsKey(prod))
            profit[prod] += amt;
        else
            profit.Add(prod, amt);

    }

    public void RecordValue(string name, float oldValue, float newValue)
    {
        valueDifference.Add(name, newValue / oldValue);
    }

    public void RecordInitialBiomeHp(string name, float value)
    {
        try
        {
            valueDifference.Add(name, value);
        }
        catch
        {
            Debug.Log("exception for: " + name + " v: " + value);
        }
    }

    public void RecordFinalBiomeHp(string name, float value)
    {
        valueDifference[name] = value / valueDifference[name];
    }

    public List<string> GetAllSignificantUpdates()
    {
        
        List<string> toReturn = new List<string>();
        foreach (KeyValuePair<string, float> kv in valueDifference)
        {
            string relation = (kv.Value < .75f)?"dropped":(kv.Value > 1.25f)?"increased":""; 
            if(relation != "")
            {
                toReturn.Add(kv.Key + " has " + relation + " to " + kv.Value*100 + " % of it's value");
            } 
        }
		string temp = "";
		foreach (string s in eventsToAnnounce) {
			temp += s;
		}
		Debug.Log ("Events to announce being added to Listener List:" + temp);
        toReturn.AddRange(eventsToAnnounce);
        foreach (KeyValuePair<string, int> kv in reoccuringMessages)
        {
            string pronoun = (kv.Value == 1)?"person":"people";
            toReturn.Add(kv.Value + " " + pronoun + " have reported that " + kv.Key);
        }

        if (profit.Count > 0)
        {
            string profitTally = "You have made ";
            foreach (KeyValuePair<Globals.product, int> kv in profit)
            {
                profitTally += kv.Value + " " + kv.Key + ", ";
            }
            profitTally += " from the townspeople.";
            toReturn.Add(profitTally);
        }

        return toReturn;
    }

    public void ClearList()
    {
        reoccuringMessages.Clear();
        valueDifference.Clear();
        eventsToAnnounce.Clear();
        profit.Clear();
    }
}
