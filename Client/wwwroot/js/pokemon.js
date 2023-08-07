// Function to fetch data from the API
const fetchData = async (url) => {
    try {
        const response = await fetch(url);
        return await response.json();
    } catch (error) {
        console.error("Error fetching data:", error);
    }
};

// Function to get the Pokemon image URL
const getPokemonImage = (sprites) => {
    if (
        sprites &&
        sprites.other &&
        sprites.other["official-artwork"] &&
        sprites.other["official-artwork"].front_default
    ) {
        return sprites.other["official-artwork"].front_default;
    }
    return "https://via.placeholder.com/150";
};

// Function to render the Pokemon statistics
const renderStatProgress = (statName, baseStat) => {
    const maxStatValue = 255; // The maximum base stat value
    const percentage = (baseStat / maxStatValue) * 100;

    let statClass = "";
    switch (statName) {
        case "hp":
            statClass = "hp";
            break;
        case "attack":
            statClass = "attack";
            break;
        case "defense":
            statClass = "defense";
            break;
        case "special-attack":
            statClass = "special-attack";
            break;
        case "special-defense":
            statClass = "special-defense";
            break;
        case "speed":
            statClass = "speed";
            break;
        default:
            statClass = "";
            break;
    }

    return `
    <div style="margin-bottom: 5px;">
      <strong>${statName}:</strong>
      <div class="progress">
        <div class="progress-bar ${statClass}" role="progressbar" style="width: ${percentage}%" aria-valuenow="${baseStat}" aria-valuemin="0" aria-valuemax="${maxStatValue}">${baseStat}</div>
      </div>
    </div>
  `;
};

// Function to handle click on a Pokemon card
const handlePokemonClick = async (name) => {
    try {
        const response = await fetchData(
            `https://pokeapi.co/api/v2/pokemon/${name}`,
        );
        const pokemonData = response;

        const speciesResponse = await fetchData(pokemonData.species.url);
        const evolutionChainResponse = await fetchData(
            speciesResponse.evolution_chain.url,
        );
        const evolutionChain = parseEvolutionChain(evolutionChainResponse.chain);

        renderPokemonModal(pokemonData, evolutionChain);
        $("#pokemonModal").modal("show");
    } catch (error) {
        console.error("Error fetching Pokemon data:", error);
    }
};

// Function to parse the evolution chain
const parseEvolutionChain = (chain) => {
    let evolutionChain = [];
    const getEvolutions = (chain) => {
        const { species, evolves_to } = chain;
        evolutionChain.push(species.name);
        if (evolves_to && evolves_to.length > 0) {
            evolves_to.forEach((evolution) => {
                getEvolutions(evolution);
            });
        }
    };
    getEvolutions(chain);
    return evolutionChain;
};

// Function to render the Pokemon modal
// const renderPokemonModal = (pokemonData, evolutionChain) => {
//     const modalTitle = document.getElementById("pokemonModalLabel");
//     const modalImage = document.getElementById("pokemonImage");
//     const modalTypes = document.getElementById("pokemonTypes");
//     const statsContainer = document.getElementById("statsContainer");
//     const evolutionList = document.getElementById("evolutionChain");
//
//     modalTitle.innerHTML = `${pokemonData.name} ${pokemonData.types
//         .map(
//             (type) =>
//                 `<img src="${getTypeIcon(type.type.name)}" alt="${
//                     type.type.name
//                 }" style="width: 40px; height: 40px;">
//                 <span style="margin: 5px; padding: 5px; border-radius: 5px;" >${type.type.name}</span>`
//            
//         )
//         .join("")}`;
//     modalImage.src = getPokemonImage(pokemonData.sprites);
//
//     statsContainer.innerHTML = `${pokemonData.stats
//         .map((stat) => renderStatProgress(stat.stat.name, stat.base_stat))
//         .join("")}`;
//
//     evolutionList.innerHTML = `${evolutionChain
//         .map(
//             (evolution) =>
//                 `<li style="cursor: pointer;" onclick="handleEvolutionChainClick('${evolution}')">${evolution}</li>`,
//         )
//         .join("")}`;
// };

const renderPokemonModal = (pokemonData, evolutionChain) => {
    const modalTitle = document.getElementById("pokemonModalLabel");
    const modalImage = document.getElementById("pokemonImage");
    const modalTypes = document.getElementById("pokemonTypes");
    const statsContainer = document.getElementById("statsContainer");
    const evolutionList = document.getElementById("evolutionChain");
    const modalElement = document.getElementById("pokemonModal");

    const typeColors = {
        normal: "rgba(168,168,120,0.5)",
        fire: "rgba(240,128,48,0.5)",
        water: "rgba(104,144,240,0.5)",
        electric: "rgba(248,208,48,0.5)",
        grass: "rgba(120,200,80,0.5)",
        ice: "rgba(152,216,216,0.5)",
        fighting: "rgba(192,48,40,0.5)",
        poison: "rgba(160,64,160,0.5)",
        ground: "rgba(224,192,104,0.5)",
        flying: "rgba(168,144,240,0.5)",
        psychic: "rgba(248,88,136,0.5)",
        bug: "rgba(168,184,32,0.5)",
        rock: "rgba(184,160,56,0.5)",
        ghost: "rgba(112,88,152,0.5)",
        dragon: "rgba(112,56,248,0.5)",
        dark: "rgba(112,88,72,0.5)",
        steel: "rgba(184,184,208,0.5)",
        fairy: "rgba(238,153,172,0.5)",
        // tambahkan warna lain sesuai dengan jenis tipe Pokemon yang Anda miliki
    };


    // Fungsi untuk membuat elemen dengan gaya latar belakang sesuai tipe Pokemon
    const createTypeElement = (type) => {
        const typeElement = document.createElement("span");
        typeElement.innerHTML = type.type.name;
        typeElement.style.margin = "5px";
        typeElement.style.padding = "5px";
        typeElement.style.borderRadius = "5px";
        typeElement.style.backgroundColor = typeColors[type.type.name];
        typeElement.style.color = "white"; // Set warna teks menjadi putih agar terlihat lebih baik pada background yang berwarna
        return typeElement;
    };

    // Bersihkan konten sebelumnya pada elemen modal
    modalTitle.innerHTML = "";
    modalTypes.innerHTML = "";
    statsContainer.innerHTML = "";
    evolutionList.innerHTML = "";

    // Tambahkan judul modal
    const modalTitleContent = document.createElement("div");
    modalTitleContent.innerHTML = `${pokemonData.name} ${pokemonData.types
        .map((type) => `<img src="${getTypeIcon(type.type.name)}" alt="${type.type.name}" style="width: 40px; height: 40px;">`)
        .join("")}`;
    modalTitle.appendChild(modalTitleContent);

    // Tambahkan tipe Pokemon ke dalam elemen modalTypes
    pokemonData.types.forEach((type) => {
        const typeElement = createTypeElement(type);
        modalTypes.appendChild(typeElement);
    });

    // Tambahkan gambar Pokemon
    modalImage.src = getPokemonImage(pokemonData.sprites);

    // Tambahkan stat Pokemon
    pokemonData.stats.forEach((stat) => {
        const statElement = document.createElement("div");
        statElement.innerHTML = renderStatProgress(stat.stat.name, stat.base_stat);
        statsContainer.appendChild(statElement);
    });

    // Tambahkan daftar evolusi Pokemon
    evolutionList.innerHTML = `${evolutionChain
        .map((evolution) => `<li style="cursor: pointer;" onclick="handleEvolutionChainClick('${evolution}')">${evolution}</li>`)
        .join("")}`;

    // Tambahkan gaya latar belakang modal sesuai dengan tipe Pokemon pertama
    const modalBackground = typeColors[pokemonData.types[0].type.name];
    modalElement.style.backgroundColor = modalBackground;
};

// Function to handle click on an evolution chain item
const handleEvolutionChainClick = (name) => {
    handlePokemonClick(name);
};

// Function to get the Pokemon type icon
const typeIcons = {
    bug: './img/bug.png',
    dark: './img/dark.png',
    dragon: './img/dragon.png',
    electric: './img/electric.png',
    fairy: './img/fairy.png',
    fighting: './img/fighting.png',
    fire: './img/fire.png',
    flying: './img/flying.png',
    ghost: './img/ghost.png',
    grass: './img/grass.png',
    ground: './img/ground.png',
    ice: './img/ice.png',
    normal: './img/normal.png',
    poison: './img/poison.png',
    psychic: './img/psychic.png',
    rock: './img/rock.png',
    steel: './img/steel.png',
    water: './img/water.png',
};

const getTypeIcon = (typeName) => {
    return typeIcons[typeName] || null;
};

// Function to render the list of Pokemon cards
const renderPokemonList = (pokemonList) => {
    const pokemonListContainer = document.getElementById("pokemonList");
    pokemonListContainer.innerHTML = "";

    let i = 1;
    pokemonList.slice(0, 50).forEach((pokemon) => {
        const card = document.createElement("div");
        card.classList.add("col-xs-6", "col-sm-4", "col-md-3");
        card.innerHTML = `
        <div class="card mb-3" style="cursor: pointer;" onclick="handlePokemonClick('${pokemon.name}')">
          <div class="card-body">
            <h5 class="card-title text-center">${pokemon.name}</h5>
          </div>
        </div>
      `;
        pokemonListContainer.appendChild(card);
    });
};

// Function to handle input change on the search field
const handleInputChange = (event) => {
    const searchQuery = event.target.value.toLowerCase();
    const filteredList = pokemonData.filter(
        (pokemon) =>
            pokemon.name.toLowerCase().includes(searchQuery)
    );
    console.log(filteredList, searchQuery);
    renderPokemonList(filteredList);
};

// Function to fetch the Pokemon list and types
const fetchPokemonData = async () => {
    try {
        const [pokemonList, types] = await Promise.all([
            fetchData("https://pokeapi.co/api/v2/pokemon?limit=1281"),
            fetchData("https://pokeapi.co/api/v2/type"),
        ]);
        pokemonData = pokemonList.results;
        renderPokemonList(pokemonList.results);
    } catch (error) {
        console.error("Error fetching Pokemon data:", error);
    }
};


// Initial data loading
let selectedType = "";
// let pokemonList = [];
let pokemonData = JSON;
fetchPokemonData();

// Event listeners
document
    .getElementById("searchInput")
    .addEventListener("input", handleInputChange);