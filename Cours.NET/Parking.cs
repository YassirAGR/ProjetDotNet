using Microsoft.VisualBasic;

public class Parking
{
  private string niveau;

  public Parking(string niveau)
  {
    this.niveau = niveau;
    DateAndTime.Now.ToString();
  }


  public string GetNiveau()
  {
    return niveau;
  }
}