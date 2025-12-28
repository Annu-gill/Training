using Day07;
// <summary>
/// Entry point class for the application.
/// Demonstrates multiple inheritance using interfaces.
/// </summary>
class Program
{
    /// <summary>
    /// Main method – execution starts from here.
    /// Shows how a single class implements multiple interfaces
    /// and how explicit interface methods are accessed.
    /// </summary>
    public static void Main(String[] args)
    {
        // /// <summary>
        // /// Accessing public methods using class reference.
        // /// </summary>
        // Birds bird = new Birds();
        // bird.SwimBird();
        // bird.FlyBird();
        // #region Interface Reference – Fly Birds
        // /// <summary>
        // /// Accessing explicit interface implementation
        // /// using IFlyBirds reference.
        // /// </summary>
        // #endregion

        // IFlyBirds flyBird = new Birds();
        // string f_rank = flyBird.GetRank();
        // Console.WriteLine(f_rank);

        // #region Interface Reference – Swim Birds
        // /// <summary>
        // /// Accessing explicit interface implementation
        // /// using ISwimBirds reference.
        // /// </summary>
        // ISwimBirds swimBird = new Birds();
        // string s_rank = swimBird.GetRank();

        // Console.WriteLine(s_rank);
        // #endregion

        // System.String str="";
    }
}



