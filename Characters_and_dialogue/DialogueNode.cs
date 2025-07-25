﻿using Dungeon_Crawler.Utilities;

namespace Dungeon_Crawler.Characters_and_dialogue
{
    public class DialogueNode
    {
        public string Statement { get; set; }
        public string[]? Response { get; set; }
        public DialogueNode[][]? FurtherDialogue { get; set; }
        public DialogueNode(string statement, string[]response, DialogueNode[][] furtherDialogue)
        {
            Statement = statement;
            Response = response;
            FurtherDialogue = furtherDialogue;
        }
        public void Node(NPC npc)
        {
            Utility.Print("");
            Utility.Print(Statement);
            Utility.Print("");
            if (Response != null) {
                Utility.Print("What do you do?");
                for (int i = 0; i < Response.Length; i++)
                {
                    Utility.Print($"{i + 1}) {Response[i]}");
                }
                int choice = Player.CharismaCheck(Response.Length);
                if (FurtherDialogue != null && FurtherDialogue.Length > 1)
                {
                    DialogueNode chosenDialogue = FurtherDialogue[choice - 1][Utility.GetRandomIndex(0, FurtherDialogue[choice - 1].Length)];
                    chosenDialogue.Node(npc);
                } else if(FurtherDialogue != null)
                {
                    DialogueNode chosenDialogue = FurtherDialogue[0][0];
                    npc.InteractionInProgress = false;
                }
            } else
            {
                npc.InteractionInProgress= false;
            }
        }
        public void Node(Boss boss)
        {
            Utility.Print(Statement);
            if (Response != null)
            {
                Utility.Print("What do you do?");
                for (int i = 0; i < Response.Length; i++)
                {
                    Utility.Print($"{i + 1}) {Response[i]}");
                }
                int choice = Utility.PrintMenu(Response.Length);
                if (FurtherDialogue != null && FurtherDialogue.Length > 1)
                {
                    DialogueNode chosenDialogue = FurtherDialogue[choice - 1][Utility.GetRandomIndex(0, FurtherDialogue[choice - 1].Length)];
                    chosenDialogue.Node(boss);
                }
                else if (FurtherDialogue != null)
                {
                    DialogueNode chosenDialogue = FurtherDialogue[0][0];
                    boss.InteractionInProgress = false;
                }
            }
            else
            {
                boss.InteractionInProgress = false;
            }
        }
    }
}
