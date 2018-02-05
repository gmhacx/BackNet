﻿using Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace ClientCommands
{
    internal class DownloadUrl : ICommand
    {
        public string name { get; } = "downloadurl";

        public string description { get; } = "Make the server download a file from the specified url";

        public string syntaxHelper { get; } = "downloadurl [url]";

        public bool isLocal { get; } = false;

        public List<string> validArguments { get; } = new List<string>()
        {
            "?"
        };


        public void Process(List<string> args)
        {
            ColorTools.WriteCommandMessage("Starting download of file from url");

            var result = ClientCommandsManager.networkManager.ReadLine();
            if (result == "Success")
            {
                ColorTools.WriteCommandSuccess("File downloaded successfully from URL");
            }
            else
            {
                ColorTools.WriteCommandError($"Download failed : {(result == "IO" ? "IO exception" : "Network error")}");
            }
        }
    }
}
