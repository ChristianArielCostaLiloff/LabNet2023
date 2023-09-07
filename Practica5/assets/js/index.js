const inputGuess = document.getElementById("guess-number");
const buttonSend = document.getElementById("button-send");
const buttonReset = document.getElementById("button-reset");
const messageHint = document.getElementById("message-hint");
const messageScore = document.getElementById("message-score");

// La puntuacion maxima se almacena en
// Inspect element > Application > Storage > Local Storage > url
let maxScoreStorage = JSON.parse(localStorage.getItem("maxScore"));

showContent();

function showContent() {
  const numberToGuess = Math.floor(Math.random() * 20) + 1;
  let inputNumber,
    maxScore = 5;
  buttonSend.addEventListener("click", function () {
    inputNumber = inputGuess.value;
    if (inputNumber > 0 && inputNumber < 20) {
      // Para visualizar el comportamiento descomentar la siguiente linea
      // console.log("Numero:" + numberToGuess + "\tPuntuacion:" + maxScore);
      if (maxScore > 0) {
        if (inputNumber > numberToGuess) {
          messageHint.innerHTML = `
              <p class="game__text">¡Ingesa un numero mas pequeño!</p>
              `;
        }
        if (inputNumber < numberToGuess) {
          messageHint.innerHTML = `
                <p class="game__text">¡Ingesa un numero mas grande!</p>
                `;
        }
        if (inputNumber == numberToGuess) {
          messageHint.innerHTML = `
              <p class="game__text">¡Acertaste el numero!</p>
              `;
          inputGuess.classList.add("game-menu__button--disabled");
          buttonSend.classList.add("game-menu__button--disabled");
          PrintMaxScore(maxScore);
        }
        maxScore--;
      }
      if (maxScore <= 0) {
        messageHint.innerHTML = `
          <p class="game__text">¡Se acabaron los intentos!</p>
          `;

        PrintMaxScore(maxScore);
        maxScore = 5;
        inputGuess.classList.add("game-menu__button--disabled");
        buttonSend.classList.add("game-menu__button--disabled");
      }
    } else {
      messageHint.innerHTML = `
        <p class="game__text">¡Ingesa un numero entre 1 y 20!</p>
        `;
    }
  });
  buttonReset.addEventListener("click", function () {
    window.location.reload();
  });
}

function PrintMaxScore(maxScore) {
  if (maxScore > maxScoreStorage) {
    localStorage.setItem("maxScore", JSON.stringify(maxScore));
  } else {
    console.log(maxScoreStorage);
    maxScoreStorage ? (maxScore = maxScoreStorage) : (maxScore = 0);
  }
  messageScore.innerHTML = `
    <p class="game__text">Puntuacion más alta: ${maxScore}</p>
    `;
}
