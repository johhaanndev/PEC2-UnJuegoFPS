# PEC2-UnJuegoFPS

**JUEGO**

Se trata de un juego FPS ambientado en un mundo de ciencia ficción. Los enemigos son drones y el objetivo es destruir un generador/célula que a primeras impresiones es la fuente de alimentación de una IA que quiere eliminar la humanidad.

El personage que el jugador controlará se llama CC. Dispone de 2 armas: fusil de asalto y pistola. Tiene recursos limitados de munición, pero podrá reabastecerse con cajas de munición que hay en el mapa. Tiene un escudo que absorbe un % de daño cuando es impactado, pero cuando se destruye por completo, una bala enemiga encajada supondrá el 100% del daño.

Los controles son WASD para moverse y el ratón para mirar. Click derecho para disparar, rueda del ratñon o 1 y 2 para cambiar de arma. R para recargar.

Cuando el jugador muere, instantáneamente reaparecerá en el inicio de la escena.

**DESARROLLO**

Existen 3 escenas, una para el menú principal y dos de juego: Menu, Main y FinalScene.

**Menu**

Es donde esán los botones para empezar partida o cerrar la aplicación.

**Main**

Donde transcurre el nivel de acción, el jugador debe destruir el generador y no morir en el intento. En esta escena encontramos un terreno montañoso con 2 edificios y drones patrullando la zona.

_Jugador_

Para el jugador se ha hecho uso del prefab en Standard Assets FirstPersonCharacter. Aún así se ha implementado un controlador para disparar que administra la munición de cada arma, y un controlador para manejar el estado de éste: la vida y la información que traspasará a la HUD.

Para la administración de armas se ha creado un objeto WeaponHolder, hijo del FirstPersonCharacter. Tiene los objetos para las armas y se administra con el objeto de ellas. Cuando el jugador usa el botón de cambio de arma, se activa la que va a usar y se desactiva la que estaba usando. Cada arma tiene una clase, clase assaultRifle y clase gun, así se puede diferenciar el daño y munición independientemente de ellas.

_Drones enemigos_

El desarrollo de los drones se ha realizado mediante una interfaz que represanta una máquina de estados. El enemigo tiene 3 estados que se monitorizan a través de un script general:

- EnemyAI: este script contiene los parámetros generales, como la vida, daño de balas, etc. Además de algunos parámetros que los estados usarán para su funcionamiento correcto. Actualiza el estado cuando este cambia y tiene implementados los métodos de impacto y disparo.
- IEnemyState: interfaz que va a ser implementada por los estados.
- PatrolState: script que describe el recorrido durante el estado de patrulla. En el mapa hay varios puntos de patrulla y este script hace que vaya de uno al otro en el orden asignado en el inspector. La luz que muestra el dron en este estado es verde. En cuanto el jugador entra en el área de alerta su estado pasa a ser AlertState.
- AlertState: describe un movimiento circular con un raycast, así si el raycast impacta con el jugador pasará al estado AttackState. Si da una vuelta y el jugador se ha alejado lo suficiente, el dron volverá al estado de patrulla. La luz es naranja.
- AttackState: el dron accederá a este estado cuando haya detectado al jugador en estado de alarma o el jugador le haya disparado en cualquier estado. La luz se pondrá roja y modificará el ángulo de proyección. Dispara al jugador con un raycast de nuevo y una probabilidad de impacto para hacer un poco más realista y dar posibilidad de fallo. Si el jugador se aleja mucho, el dron le perseguirá durante 2 segundos, si no se ha acercado volverá al estado de patrulla.

_Objetos recolectables_

Por el mapa hay 3 objetos recolectables. Todos tres son triggers que en ser cruzados por el collider del jugador desaparecerán y le darán el recurso al jugador.

Las esferas de vida y escudo, además proporcionarán una notificación visual al jugador cuando sean recolectadas. La vida activará un marco verde y el escudo uno azul.

_Detalles_

El juego tiene una pequeña historia, esta está contada con diálogos. Esta medida sería mucho más óptima y beneficiosa para el jugador si fueran con voz, pero debido a que no se tiene este recurso se ha hecho escribiendo subtítulos.

El objetivo es destruir un generador, pero este está ubicado en el interior de un edificio y para acceder se tiene primero que destruir un pequeño aparato rojo también. Deberá buscarlo y destruirlo. Si se llega al edificio sin haberlo destruido, saltará un aviso mencionando este dispositivo rojo.

**FinalScene**

Se trata de una escena con poco gameplay y más narrativa. Cuenta un giro en la historia y el jugador se encuentra en un mundo oscuro que sólo tiene una dirección que seguir. El camino se va iluminando a medida que avanza hasta la siguiente sala iluminada. Cuando supera una sala, esta se destruye evitando que pueda volver atrás.

En esta escena se ha desarrollado la plataforma móvil. Su desarrollo es simple: una animación en bucle y un trigger encima. Cuando el jugador acciona el trigger, el objeto de jugador pasa a ser hijo de la plataforma, así puede desplazarse con la plataforma y relativamente a ella. Cuando sale del trigger, vuelve a no tener parent.
