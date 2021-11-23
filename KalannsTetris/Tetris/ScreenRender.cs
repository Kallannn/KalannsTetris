using System;
using System.Collections.Generic;
using System.Text;

namespace KalannsTetris.Tetris
{
    public class ScreenRender
    {
        public int[,] fieldData { get; set; }
        public string[,] fieldScreen { get; set; }
        private int fieldScreen_Width = 41;//(TetrisConstants.fieldTelaLargura * 3) + 1;
        private int fieldScreen_Heigth = 41;//(TetrisConstants.fieldTelaAltura * 2) + 1;

        /** <summary>Método que utiliza todos os recursos da classe para criar a tela completa </summary> */
        public void ScreenRender_ExecuteWholeProcess(int[,] data)
        {
            Console.Clear();
            DataSetup(data);
            AddFrameToScreen();
            FillBlank();
            BlockPainter();
            WriteScreenOnConsole();
        }

        /** <summary> Método para inserir o array do jogo (20x10) que será desenhado na tela </summary> */
        private void DataSetup(int[,] fieldData)
        {
            this.fieldData = fieldData;
            fieldScreen = new string[fieldScreen_Heigth, fieldScreen_Width];
        }

        /** <summary>Método que cria uma moldura ao redor da tela</summary> */
        private void AddFrameToScreen()
        {
            for(int y =0; y<= fieldScreen_Width - 1; y++)
            {
                fieldScreen[0, y] = TetrisConstants.horizontalSeparator;
                fieldScreen[fieldScreen_Heigth - 1, y] = TetrisConstants.horizontalSeparator;
            }
            for (int x = 0; x <= fieldScreen_Heigth - 1; x++)
            {
                fieldScreen[x, 0] = TetrisConstants.verticalSeparator;
                fieldScreen[x, fieldScreen_Width - 1] = TetrisConstants.verticalSeparator;
            }
        }

        /** <summary>Método que desenha a tela final do console</summary> */
        private void WriteScreenOnConsole()
        {
            StringBuilder linha = new StringBuilder();
            for (int x = 0; x <= fieldScreen_Heigth-1; x++)
            {
                for (int y = 0; y <= fieldScreen_Width-1; y++)
                {
                    linha.Append(fieldScreen[x, y]);
                }
                Console.WriteLine(linha.ToString());
                linha.Clear();
            }
        }

        /** <summary>Método que substitui todas as casas vazias na tela por um espaço (" ")</summary> */
        private void FillBlank()
        {
            for (int x = 0; x <= fieldScreen_Heigth - 1; x++)
            {
                for (int y = 0; y <= fieldScreen_Width - 1; y++)
                {
                    if(fieldScreen[x,y] == null)
                    {
                        fieldScreen[x, y] = " ";
                    }
                }
            }
        }

        /** <summary>Função que desenha os blocos na tela como serão exibidos no final</summary> */
        private void DrawBiggerBlocks(int xRaw,int yRaw)
        {
            int x = (1) + (xRaw * 2); ;
            int y = ( 1 ) + (yRaw * 4 );

            fieldScreen[x    , y - 1] = TetrisConstants.verticalSeparator;
            fieldScreen[x + 1, y - 1] = TetrisConstants.verticalSeparator;
            fieldScreen[x    , y + 3] = TetrisConstants.verticalSeparator;
            fieldScreen[x + 1, y + 3] = TetrisConstants.verticalSeparator;

            fieldScreen[x - 1, y    ] = TetrisConstants.horizontalSeparator; 
            fieldScreen[x - 1, y + 1] = TetrisConstants.horizontalSeparator;
            fieldScreen[x - 1, y + 2] = TetrisConstants.horizontalSeparator;
            fieldScreen[x + 1, y    ] = TetrisConstants.horizontalSeparator;
            fieldScreen[x + 1, y + 1] = TetrisConstants.horizontalSeparator;
            fieldScreen[x + 1, y + 2] = TetrisConstants.horizontalSeparator;
        }
        private void BlockPainter()
        {
            for (int x = 0; x <= TetrisConstants.fieldHeight - 1; x++)
            {
                for (int y = 0; y <= TetrisConstants.fieldWidth - 1; y++)
                {
                    if (fieldData[x, y] != 0)
                    {
                        DrawBiggerBlocks(x, y);
                    }
                }
            }
        }
    }
}
