using System.ComponentModel.DataAnnotations;
using System.Drawing;

public class SolidObject
{
    private float radius;
    private float weight;
    private float elasticity;
    private Color color;
    private float posX, posY;
    private float velocityX, velocityY;



    public void timeiteration(float deltaT, float gravity)
    {
        posX += deltaT * velocityX;
        posY += deltaT * velocityY;
        velocityY += deltaT * gravity;
    }


    public float getcoordinatesX()
    {
        return posX;
    }

    public float getcoordinatesY()
    {
        return posY;
    }

    public SolidObject(float radius, float weight, float elasticity, Color color, float posX, float posY, float velocityX, float velocityY)
    {
        this.radius = radius;
        this.weight = weight;
        this.elasticity = elasticity;
        this.color = color;
        this.posX = posX;
        this.posY = posY;
        this.velocityX = velocityX;
        this.velocityY = velocityY;
        
    }
}
public class Environment
{
    SolidObject[] balls = Array.Empty<SolidObject>();
    private float gravity = -9.81f;
    private float deltaT = 0.001f;

    public float distance(int i,int j)
    {
        float ball1x, ball2x, ball1y, ball2y;
        float d;
        ball1x = balls[i].getcoordinatesX();
        ball2x = balls[j].getcoordinatesX();
        ball1y = balls[i].getcoordinatesY();
        ball2y = balls[j].getcoordinatesY();
         
        d = MathF.Pow(MathF.Pow(ball1x-ball2x, 2)+ MathF.Pow(ball1y-ball2y, 2), 0.5f);
        return d;
    }
    
    public void checkInt()
    {
        for (int i = 0; i < balls.Length; i++)
        {
            for(int j = i + 1; j < balls.Length; j++)
            {
                float d = distance(i, j);
                // TODO: get deformation and calculate force
            }

        }
    }
    public void addBall(SolidObject ball)
    {
        Array.Resize(ref balls, balls.Length + 1);
        balls[balls.Length - 1] = ball;
      
    }
    public Environment(float gravity, float deltaT) 
    {
        this.gravity = gravity;
        this.deltaT = deltaT;
    
    }

    public void timeIteration()
    {
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].timeiteration(deltaT, gravity);
        }
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
        SolidObject ball = new SolidObject(1, 10, 1, Color.Red, 0, 0, 1, 1);
        Environment env = new Environment(-9.0f, 0.1f);
        env.addBall(ball);
        for (int i = 0; i < 10; i++)
        {
            env.timeIteration();
            Console.WriteLine(ball.getcoordinatesX());
            Console.WriteLine(ball.getcoordinatesY());
        }
    }
}
