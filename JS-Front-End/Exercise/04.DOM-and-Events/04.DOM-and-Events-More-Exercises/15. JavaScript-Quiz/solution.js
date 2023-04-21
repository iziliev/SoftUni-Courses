function solve() {
  let points = 0
  const questions = Array.from(document.querySelectorAll('section'))
  let correctAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];
  let index = 0


    Array.from(document.querySelectorAll('.quiz-answer'))
    .map((x)=>x.addEventListener('click',(makeAnswer)=>{
      let answer = makeAnswer.target.innerHTML
      if(correctAnswers.includes(answer)){
        points++
      }
      questions[index].style.display = 'none'
      index++

      if(index!=3){
        questions[index].style.display = 'block'
      } else {
        result(points)
      }
    }))
  
  function result(points){
    document.getElementById('results').style.display = 'block'
    let text = ''
    if (points === 3) {
      text = `You are recognized as top JavaScript fan!`
    } else {
      text = `You have ${points} right answers`
    }
    document.querySelector('#results > li > h1').textContent = text
  }

}


// let points = 0;
//   let correctAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];
//   let index = 0;
//   let question = document.getElementsByTagName('section');

//   Array.from(document.querySelectorAll('.quiz-answer'))
//       .map((x) => x.addEventListener('click', (answer) => {
//           if (correctAnswers.includes(answer.target.innerHTML)) {
//               points++;
//           };
//           question[index].style.display = 'none';
//           index++;

//           index !== 3
//               ? question[index].style.display = 'block'
//               : printResult(points);
//       }));
//   function printResult(points) {
//       document.querySelector("#results").style.display = 'block';
//       let text = '';
//       points === 3
//           ? text = 'You are recognized as top JavaScript fan!'
//           : text = `You have ${points} right answers`;
//       document.querySelector("#results > li > h1").textContent = text;
//   }