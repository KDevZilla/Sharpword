# Sharpword
 Wordle using C#  
 


![Game Animation](https://user-images.githubusercontent.com/108615376/202889375-d00a5528-a166-4252-ba0f-22f3a0217425.gif)


You can look for a project article I post it on 2 places.
The contents are the same.

https://www.codeproject.com/Articles/5347429/Sharpword  
https://github.com/KDevZilla/ArticlesPublic/blob/main/Sharpword.md


# How to setup a project
1. Just download a project, it is just a small program written in C# Windows Form.
2. There are 2 projects
      Sharpword: This is the main project
      SharpWordUnitTest: This it the test project

3. The nesecially file already being configured as "Copy to Output Directory" so you no need to manually 
copy or configure anything, jut run the program
4. For testing the project, you can just run The test cases in UnitTestSharpWordGame.class


# Bug fixed

1. 2022-11-20 The incorrect color in case there are more than one character user guess while there is only one correct character.  
In this below case the color of the fist P must be gray not yellow.  
Thank to https://www.reddit.com/user/elvishfiend/ to point out

Before fix  
![SharpWord_Incorrect_TileResult](https://user-images.githubusercontent.com/108615376/202889171-5d805908-4417-4055-b35a-3283db27e064.png)

After fixed  
![SharpWord_Fixed_TileResult](https://user-images.githubusercontent.com/108615376/202889174-c8398eb9-5470-48de-93a9-10a7f3b67ad7.png)


2. 2022-11-20 The incorrect color also   
Thank to https://www.reddit.com/user/m4trixglitch/   
Before fix  
![SharpWord_Incorrect_TileResult_02](https://user-images.githubusercontent.com/108615376/202912138-c1e21c15-d372-4692-801b-c6f0fa0c207a.png)

After fixed  
![SharpWord_Fixed_TileResult_02](https://user-images.githubusercontent.com/108615376/202912157-4521ff80-6754-496c-ab33-e03172f6a15b.png)
