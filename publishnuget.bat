dotnet nuget push "src/OpenAI.Mock/bin/Debug/OpenAI.Mock.1.0.0.nupkg"  --source "github" --api-key "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"


:: dotnet tool install -g OpenAI.Mock --version 1.0.0 --add-source https://nuget.pkg.github.com/NetizineLtd/index.json

:: Launch with openai-mock --port 5000

:: dotnet tool uninstall OpenAI.Mock -g