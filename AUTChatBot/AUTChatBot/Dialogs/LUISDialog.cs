using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using static AUTChatBot.BotDatabase.SQLDatabaseClient;

namespace AUTChatBot.Dialogs
{
    [LuisModel("{289207be-4047-43a8-9486-f5230a1cb781}", "{398bf4c98ecb4f8ea1c9b71b9baaedb5}")]
    [Serializable]
    public class LUISDialog : LuisDialog<object>
    {
        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Sorry, Can you write your message in a different way to help me understand?");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Greet")]
        public async Task Greet(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Hello, I am the AUT Chatbot, Please ask me about any papers you need help with.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Request Paper Code")]
        public async Task RequestPaperCode(IDialogContext context, LuisResult result)
        {
            var valuesEntity = result.Entities;
            Paper paper = GetPaper(valuesEntity[0].Resolution.Values.FirstOrDefault().ToString(), false);
            await context.PostAsync("The paper code is " + paper.PaperCode);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Request Paper Name")]
        public async Task RequestPaperName(IDialogContext context, LuisResult result)
        {
            var valuesEntity = result.Entities;
            Paper paper = GetPaper(valuesEntity[0].Resolution.Values.FirstOrDefault().ToString(), true);
            await context.PostAsync("The paper Name is " + paper.PaperName);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Request Paper Prerequisites")]
        public async Task RequestPaperPreRequisites(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Sorry, Can you write your message in a different way to help me understand?");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Request Paper Corequisites")]
        public async Task RequestPaperCoRequisites(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Sorry, Can you write your message in a different way to help me understand?");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Check Paper in Major")]
        public async Task CheckPaperInMajor(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Sorry, Can you write your message in a different way to help me understand?");
            context.Wait(MessageReceived);
        }
    }
}