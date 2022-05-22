# Unity SignalR Android/IOS Plugin
Work on PC, IOS, Android.
Unity 2018+.
# Setup:
1. Add plugins file in your project.
2. Add SignalR class to object on scene.
3. Set url and if needed token.
4. In Player Settings -> Android/IOS -> Other Settings -> Configuration: 
    Scripting backend select IL2CPP.
    Api Compatibility Level select .NetStandart.
    Internet Access select Require.
5. Run and build project.

# Send request
This class has a "Send" method. Call it, pass in the generics the type of the object being passed and the object being desilirized. In the parameters, pass the link and the object itself.

# Json serialization
Standard Newtonsoft does not work on mobile devices.
System.Text.Json does not serialize Enum and Nullable type.
If you need to deserialize all types without problems, then it is advised to install custom Newtonsoft. All instructions will be in the script itself.

