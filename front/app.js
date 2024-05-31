var baseRoute = "http://localhost:5248/api"

window.onload = async () => {
    await Reiniciar();
    await Status();
}

const Reiniciar = async () => await fetch(baseRoute + "/Robo/Reiniciar", { method: "POST" })

const Status = async () => {
    const robo = await fetch(baseRoute + "/Robo/Status").then(x => x.json())
    document.getElementById("pulso-esquerdo-status").innerHTML = robo.esquerdo.pulso.replace("_", " ");
    document.getElementById("pulso-direito-status").innerHTML = robo.direito.pulso.replace("_", " ");
    document.getElementById("cotovelo-esquerdo-status").innerHTML = robo.esquerdo.cotovelo.replace("_", " ");
    document.getElementById("cotovelo-direito-status").innerHTML = robo.direito.cotovelo.replace("_", " ");
    document.getElementById("inclinacao-status").innerHTML = robo.cabeca.inclinacao.replace("_", " ");
    document.getElementById("rotacao-status").innerHTML = robo.cabeca.rotacao.replace("_", " ");

    ValidarBtnCotovelo(robo.direito.cotovelo, 'direito')
    ValidarBtnCotovelo(robo.esquerdo.cotovelo, 'esquerdo')
    ValidarBtnPulso(robo.direito.pulso, 'direito')
    ValidarBtnPulso(robo.esquerdo.pulso, 'esquerdo')
    ValidarBtnCabeça(robo.cabeca)

}
const ValidarBtnCotovelo = (cotovelo, lado) => {
    document.getElementById("cotovelo-" + lado + "-btn-contrair").disabled = (cotovelo == "Fortemente_Contraido");
    document.getElementById("cotovelo-" + lado + "-btn-descontrair").disabled = (cotovelo == "Repouso");
}

const ValidarBtnPulso = (pulso, lado) => {
    cotoveloContraido = document.getElementById("cotovelo-" + lado + "-btn-contrair").disabled
    document.getElementById("pulso-" + lado + "-btn-positivo").disabled = (pulso == "Positivo_180") || !cotoveloContraido;
    document.getElementById("pulso-" + lado + "-btn-negativo").disabled = (pulso == "Negativo_90") || !cotoveloContraido;
}

const ValidarBtnCabeça = (cabeca) => {
    document.getElementById("cabeca-inclinacao-btn-cima").disabled = (cabeca.inclinacao == 'Cima');
    document.getElementById("cabeca-inclinacao-btn-baixo").disabled = (cabeca.inclinacao == 'Baixo');

    document.getElementById("cabeca-rotacao-btn-positivo").disabled = (cabeca.rotacao == 'Positivo_90' || cabeca.inclinacao == 'Baixo');
    document.getElementById("cabeca-rotacao-btn-negativo").disabled = (cabeca.rotacao == 'Negativo_90' || cabeca.inclinacao == 'Baixo');
}
const CotoveloSetup = async (lado, acao) => {
    await fetch(baseRoute + "/Robo/Braco/Cotovelo/" + lado + acao, { method: "POST" })
    await Status();
}


const PulsoSetup = async (lado, acao) => {
    await fetch(baseRoute + "/Robo/Braco/Pulso/" + lado + acao, { method: "POST" })
    await Status();
}

const CabecaSetup = async (angulo, acao) => {
    await fetch(baseRoute + "/Robo/Cabeca/" + angulo + acao, { method: "POST" })
    await Status();
}

