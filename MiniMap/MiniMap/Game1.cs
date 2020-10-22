using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MiniMap
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D bigMap;
        Rectangle bigMapRect;
        Rectangle smallMapRect;

        Texture2D square;
        Rectangle squareRectangle;

        double mapX = -100;
        double mapY = -100;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            bigMapRect = new Rectangle((int)mapX, (int)mapY, 1600, 1600);
            smallMapRect = new Rectangle(0, 0, 160, 160);
            squareRectangle = new Rectangle((int)mapX / 10, (int)mapY / 10,80,48);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            square = this.Content.Load<Texture2D>("squareselector");
            bigMap = this.Content.Load<Texture2D>("Map");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            GamePadState pad = GamePad.GetState(PlayerIndex.One);
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            mapX -= pad.ThumbSticks.Left.X * 3;
            mapY += pad.ThumbSticks.Left.Y * 3;
            if (mapX < -800) {
                mapX = -800;
            }
            if (mapX > 0) {
                mapX = 0;
            }
            if (mapY < -1120) {
                mapY = -1120;
            }
            if (mapY > 0) {
                mapY = 0;
            }
            bigMapRect = new Rectangle((int)mapX, (int)mapY, 1600, 1600);
            // TODO: Add your update logic here
            squareRectangle = new Rectangle(( -(int)mapX) / 10, (int)-mapY / 10, 80, 48);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(bigMap, bigMapRect, Color.White);
            spriteBatch.Draw(bigMap, smallMapRect, Color.White);
            spriteBatch.Draw(square, squareRectangle, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
