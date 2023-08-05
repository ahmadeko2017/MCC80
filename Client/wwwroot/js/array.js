//array of object
const animals = [
    { name: "dory", species: "fish", class: { name:"vertebrata"}},
    { name: "tom", species: "cat", class: { name:"mamalia"}},
    { name: "nemo", species: "fish", class: { name:"vertebrata"}},
    { name: "umar", species: "cat", class: { name:"mamalia"}},
    { name: "gary", species: "fish", class: { name:"human"}},
]

//bikin sebuah looping ke animals, 2 fungsi :
//fungsi 1: jika species nya 'cat' maka ambil lalu pindahkan ke variabel OnlyCat
//fungsi 2: jika species nya 'fish' maka ganti class -> menjadi 'non-mamalia'

// Fungsi 1: Memindahkan species 'cat' ke variabel OnlyCat
const OnlyCat = animals.filter(animal => animal.species === "cat");

// Fungsi 2: Mengganti class menjadi 'non-mamalia' untuk species 'fish'
const updatedAnimals = animals.map(animal => {
    if (animal.species === "fish") {
        animal.class.name = "non-mamalia";
    }
    return animal;
});