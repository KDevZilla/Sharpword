# Sharpword
 Wordle using C#  
 
![Game Animation](https://raw.githubusercontent.com/KDevZilla/Resource/main/SharpWord01.gif)



You can look for a project article I post it 2 places.
The gif image on codeproject might does not do animation.

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


# Bug fiexed
2022-11-20 The incorrect color in case there are more than one character user guess while there is only one correct character.  
In this below case the color of the fist P must be gray not yellow.  
Thank to https://www.reddit.com/user/elvishfiend/ to point out

Before fix  
![SharpWord_Incorrect_TileResult](https://user-images.githubusercontent.com/108615376/202889171-5d805908-4417-4055-b35a-3283db27e064.png)

After fixed  
![SharpWord_Fixed_TileResult](https://user-images.githubusercontent.com/108615376/202889174-c8398eb9-5470-48de-93a9-10a7f3b67ad7.png)
