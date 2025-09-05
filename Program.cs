
using System.Drawing;

public class SolidObject
{
    private float radius;
    private float weight;
    private float elasticity;
    private Color color;
    private float friction;
    private float posX, posY;
    private float velocityX, velocityY;
    private float gravity = -9.81f;


    public void timeiterattion(float deltaT)
    {
        posX += deltaT * velocityX;
        posY += deltaT * velocityY;
        velocityY += deltaT * gravity;
        velocityY += deltaT * friction;
        velocityX += deltaT * friction;
    }


    public float getcoordinatesX()
    {
        return posX;
    }

    public float getcoordinatesY()
    {
        return posY;
    }

    public SolidObject(float radius, float weight, float elasticity, Color color, float friction, float posX, float posY, float velocityX, float velocityY,  float gravity)
    {
        this.radius = radius;
        this.weight = weight;
        this.elasticity = elasticity;
        this.color = color;
        this.friction = friction;
        this.posX = posX;
        this.posY = posY;
        this.velocityX = velocityX;
        this.velocityY = velocityY;
        this.gravity = gravity;
    }
}

public class Slingshot
{
    private float slingX = 0.0f;
    private float slingY = 1.0f;

    private float pullX = -1f;
    private float pullY = -1f;
}

class Program
{
    static void Main(string[] args)
    {
        SolidObject Ball = new SolidObject(1, 10, 1, Color.Red, -1, 0, 0, 1, 1, -9);

        for (int i = 0; i < 10; i++)
        {
            Ball.timeiterattion(1);
            Ball.getcoordinatesX();
            Ball.getcoordinatesY();
            Console.WriteLine(Ball.getcoordinatesX());
            Console.WriteLine(Ball.getcoordinatesY());
        }
    }
}

