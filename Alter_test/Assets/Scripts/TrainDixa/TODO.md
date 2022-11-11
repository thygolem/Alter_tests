# ENTRENA TU VISTA

[ejemplo de python auto](https://luispedro.org/software/mahotas/)
[algoritmos python](https://stackoverflow.com/questions/8849869/how-do-i-find-wally-with-python)



# ¿En qué consiste el juego?
- Pulsar con el raton sobre la pelota sin que leguen a tocar el suelo
- Interactividad uso del raton
- Las rampas impiden qu el as pelotas caigan direcrectamente al suelo



# ¿Qué objetos identificas?
## Pelota:
    - Al pulsar sobre ella obtenemos un apuntuacion
    - Aparecen de manera aleatoria desde la parte superior
    - hay pelotas de diferentes:
        - Puntuacion
        - Tamaño
        - Color
    - La posición inical de la pelota es aleatroia con una cierta altura
        - Aleatroria en el eje x
        - Altura(eje y) constante
    - La creación de la pelota también tiene cierta aleatoriedad
    - Debe haber un maximo de pelotas por pantalla
    
## Suelo:
    - Si la pelota toca el suelo, pierdes

## Rampa:
    - Colisiones con las pelotas

## Cursor:
    - representa el avatar del jugador

## Marcadores:
    - Hay un marcador de la puntuación actual (Scrore)
    - Hay marcador4 de la maxima puntuación

## Menú:
    - Botón de play:
        - Iniciar el juego al ser pulsado y desaparece durante el juego
        - Reaparcece cuando finaliza la partida(cae una pelota al suelo)

¿Qué objetos son puramente estáticos y cuáles tienen comportamiento?

¿Qué comportamientos identificas?

¿Quién tiene la resposabilidad de esos comportamientos?

¿Qué elementos tienen el HUD (Head Up Display)?