using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

namespace AUTChatBot.Dialogs
{
    [LuisModel("{luis_app_id}", "{subscription_key}")]
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
            await context.PostAsync("Sorry, Can you write your message in a different way to help me understand?");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Request Paper Name")]
        public async Task RequestPaperName(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Sorry, Can you write your message in a different way to help me understand?");
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