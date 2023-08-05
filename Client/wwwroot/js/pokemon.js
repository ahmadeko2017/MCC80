import React, { useState, useEffect } from 'react';
import axios from 'axios';
import {Modal, Button, Row, Col, Card, Tooltip, ProgressBar} from 'react-bootstrap';

import bugIcon from './img/bug.png';
import darkIcon from './img/dark.png';
import dragonIcon from './img/dragon.png';
import electricityIcon from './img/electric.png';
import fairyIcon from './img/fairy.png';
import fightingIcon from './img/fighting.png';
import fireIcon from './img/fire.png';
import flyingIcon from './img/flying.png';
import ghostIcon from './img/ghost.png';
import grassIcon from './img/grass.png';
import groundIcon from './img/ground.png';
import iceIcon from './img/ice.png';
import normalIcon from './img/normal.png';
import poisonIcon from './img/poison.png';
import psychicIcon from './img/psychic.png';
import rockIcon from './img/rock.png';
import steelIcon from './img/steel.png';
import waterIcon from './img/water.png';


const pokemon = () => {
    const [pokemonList, setPokemonList] = useState([]);
    const [filteredPokemonList, setFilteredPokemonList] = useState([]);
    const [searchQuery, setSearchQuery] = useState('');
    const [selectedType, setSelectedType] = useState('');
    const [types, setTypes] = useState([]);
    const [activePokemon, setActivePokemon] = useState(null);
    const [selectedPokemon, setSelectedPokemon] = useState(null);
    const [showModal, setShowModal] = useState(false);
    const [pokemonData, setPokemonData] = useState(null);
    const [evolutionChain, setEvolutionChain] = useState([]);

    useEffect(() => {
        const fetchPokemonList = async () => {
            try {
                const response = await axios.get('https://pokeapi.co/api/v2/pokemon?limit=1281');
                setPokemonList(response.data.results);
            } catch (error) {
                console.error('Error fetching Pokemon list:', error);
            }
        };

        const fetchPokemonTypes = async () => {
            try {
                const response = await axios.get('https://pokeapi.co/api/v2/type');
                setTypes(response.data.results);
            } catch (error) {
                console.error('Error fetching Pokemon types:', error);
            }
        };

        fetchPokemonList();
        fetchPokemonTypes();
    }, []);

    useEffect(() => {
        // Filter the list based on search query and selected type
        const filteredList = pokemonList.filter(
            (pokemon) =>
                pokemon.name.toLowerCase().includes(searchQuery.toLowerCase()) &&
                (!selectedType || pokemon.types.some((type) => type.type.name === selectedType))
        );
        setFilteredPokemonList(filteredList);
    }, [searchQuery, selectedType, pokemonList]);

    const getPokemonImage = () => {
        if (pokemonData && pokemonData.sprites) {
            return pokemonData.sprites.other['official-artwork'].front_default;
        }
        return 'https://via.placeholder.com/150';
    };
    const handleInputChange = (event) => {
        setSearchQuery(event.target.value);
    };
    const handlePokemonClick = async (name) => {
        setActivePokemon(name);
        setSelectedPokemon(name);
        setShowModal(true);

        try {
            const response = await axios.get(`https://pokeapi.co/api/v2/pokemon/${name}`);
            setPokemonData(response.data);

            const speciesResponse = await axios.get(response.data.species.url);
            const evolutionChainResponse = await axios.get(speciesResponse.data.evolution_chain.url);
            const evolutionChain = parseEvolutionChain(evolutionChainResponse.data.chain);
            setEvolutionChain(evolutionChain);
        } catch (error) {
            console.error('Error fetching Pokemon data:', error);
        }
    };

    const handleEvolutionChainClick = (name) => {
        handlePokemonClick(name);
    };

    const handleCloseModal = () => {
        setShowModal(false);
    };

    const renderStatProgress = (statName, baseStat) => {
        const maxStatValue = 255; // The maximum base stat value
        const percentage = (baseStat / maxStatValue) * 100;

        return (
            <div key={statName} style={{ marginBottom: '5px' }}>
                <strong>{statName}:</strong>
                <ProgressBar now={baseStat} max={maxStatValue} label={baseStat} animated/>
            </div>
        );
    };

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

    const renderTooltip = (types) => (
        <Tooltip id={`tooltip`}>
            {types.map((type) => (
                <span key={type.type.name} style={{ margin: '5px', padding: '5px', borderRadius: '5px' }}>
          {type.type.name}
        </span>
            ))}
        </Tooltip>
    );

    const getTypeIcon = (typeName) => {
        switch (typeName) {
            case 'bug':
                return bugIcon;
            case 'dark':
                return darkIcon;
            case 'dragon':
                return dragonIcon;
            case 'electric':
                return electricityIcon;
            case 'fairy':
                return fairyIcon;
            case 'fighting':
                return fightingIcon;
            case 'fire':
                return fireIcon;
            case 'flying':
                return flyingIcon;
            case 'ghost':
                return ghostIcon;
            case 'grass':
                return grassIcon;
            case 'ground':
                return groundIcon;
            case 'ice':
                return iceIcon;
            case 'normal':
                return normalIcon;
            case 'poison':
                return poisonIcon;
            case 'psychic':
                return psychicIcon;
            case 'rock':
                return rockIcon;
            case 'steel':
                return steelIcon;
            case 'water':
                return waterIcon;
            // Add other cases for other types
            default:
                return null;
        }
    };

    return (
        <div className="container">
            <div className="container sticky-top bg-white p-3">
                <h2 className="text-center mb-4">Pokédex</h2>
                <div className="input-group mb-3">
                    <input
                        type="text"
                        className="form-control"
                        placeholder="Search Pokemon..."
                        value={searchQuery}
                        onChange={handleInputChange}
                    />
                </div>
            </div>
            <Row>
                {filteredPokemonList.slice(0, 50).map((pokemon) => (
                    <Col xs={6} sm={4} md={3} key={pokemon.name}>
                        <Card
                            className="mb-3"
                            style={{ cursor: 'pointer' }}
                            onClick={() => handlePokemonClick(pokemon.name)}
                        >
                            <Card.Body>
                                <Card.Title className="text-center">{pokemon.name}</Card.Title>
                            </Card.Body>
                        </Card>
                    </Col>
                ))}
            </Row>
            <Modal show={showModal} onHide={handleCloseModal} className="modal-lg">
                <Modal.Header closeButton>
                    <Modal.Title>{pokemonData?.name} <span> </span>
                        {pokemonData?.types.map((type) => (
                            <img
                                key={type.type.name}
                                src={getTypeIcon(type.type.name)}
                                alt={type.type.name}
                                style={{
                                    width: '40px',
                                    height: '40px',
                                }}
                            />
                        ))}</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Row>

                        <Col xs={12} md={6}>
                            <img
                                src={getPokemonImage(pokemonData?.name)}
                                alt={pokemonData?.name}
                                style={{ width: '100%' }}
                            />
                        </Col>
                        <Col xs={12} md={6}>
                            <h4>Statistics:</h4>
                            <div>
                                {pokemonData?.stats.map((stat) =>
                                    renderStatProgress(stat.stat.name, stat.base_stat)
                                )}
                            </div>
                            <h4>Evolution Chain:</h4>
                            <ul>
                                {evolutionChain.map((evolution) => (
                                    <li
                                        key={evolution}
                                        style={{ cursor: 'pointer' }}
                                        onClick={() => handleEvolutionChainClick(evolution)}
                                    >
                                        {evolution}
                                    </li>
                                ))}
                            </ul>
                        </Col>
                    </Row>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleCloseModal}>
                        Close
                    </Button>
                </Modal.Footer>
            </Modal>
        </div>
    );
};

export default pokemon;
