import { Component, Inject } from '@angular/core';
import { HttpClient, HttpXhrBackend } from '@angular/common/http';

@Component({
  selector: 'app-films-component',
  templateUrl: './films.component.html'
})

export class FilmsComponent {

  public results: Results[] = [];

  constructor(private http: HttpClient) {
    http.get<Film>("https://swapi.dev/api/films").subscribe(result => {
      this.results = result.results;
    }, error => console.error(error));
  }

  getFilmCharacters(id: number) {
    var result = this.results.find(x => x.episode_id == id);

    var index = this.results.findIndex(x => x.episode_id == id);

    if (index >= 0 && this.results[index].charactersInfo == null) {

      this.results[index].charactersInfo = [];

      result?.characters.forEach(x => {
        this.http.get<Character>(x).subscribe(result => {
          this.results[index].charactersInfo.push(result);
        }, error => console.error(error));
      }) 
    }   
  }

  getFilmPlanets(id: number) {
    var result = this.results.find(x => x.episode_id == id);

    var index = this.results.findIndex(x => x.episode_id == id);

    if (index >= 0 && this.results[index].planetsInfo == null) {

      this.results[index].planetsInfo = [];

      result?.planets.forEach(x => {
        this.http.get<Planet>(x).subscribe(result => {
          this.results[index].planetsInfo.push(result);
        }, error => console.error(error));
      })
    }
  }

  getFilmStarships(id: number) {
    var result = this.results.find(x => x.episode_id == id);

    var index = this.results.findIndex(x => x.episode_id == id);

    if (index >= 0 && this.results[index].starshipsInfo == null) {

      this.results[index].starshipsInfo = [];

      result?.starships.forEach(x => {
        this.http.get<Starship>(x).subscribe(result => {
          this.results[index].starshipsInfo.push(result);
        }, error => console.error(error));
      })
    }
  }

  getFilmVehicles(id: number) {
    var result = this.results.find(x => x.episode_id == id);

    var index = this.results.findIndex(x => x.episode_id == id);

    if (index >= 0 && this.results[index].vehiclesInfo == null) {

      this.results[index].vehiclesInfo = [];

      result?.vehicles.forEach(x => {
        this.http.get<Vehicle>(x).subscribe(result => {
          this.results[index].vehiclesInfo.push(result);
        }, error => console.error(error));
      })
    }
  }

  getFilmSpecies(id: number) {
    var result = this.results.find(x => x.episode_id == id);

    var index = this.results.findIndex(x => x.episode_id == id);

    if (index >= 0 && this.results[index].speciesInfo == null) {

      this.results[index].speciesInfo = [];

      result?.species.forEach(x => {
        this.http.get<Specie>(x).subscribe(result => {
          this.results[index].speciesInfo.push(result);
        }, error => console.error(error));
      })
    }
  }
}

interface Film {
  count: string;
  results: Results[];
}

interface Results {
  title: string;
  episode_id: number;
  opening_crawl: string;
  director: string;
  producer: string;
  release_date: string;
  characters: string[];
  charactersInfo: Character[];
  planets: string[];
  planetsInfo: Planet[];
  starships: string[];
  starshipsInfo: Starship[];
  vehicles: string[];
  vehiclesInfo: Vehicle[];
  species: string[];
  speciesInfo: Specie[];
}

interface Character {
  name: string;
  height: string;
  mass: string;
  hair_color: string;
  skin_color: string;
  eye_color: string;
  birth_year: string;
  gender: string
}

interface Planet {
  name: string;
  rotation_period: string;
  orbital_period: string;
  diameter: string;
  climate: string;
  gravity: string;
  terrain: string;
  surface_water: string
  population: string;
}

interface Starship { 
  name: string;
  model: string;
  manufacturer: string;
  cost_in_credits: string;
  length: string;
  max_atmosphering_speed: string;
  crew: string
  passengers: string;
  cargo_capacity: string;
  consumables: string;
  hyperdrive_rating: string;
  MGLT: string;
  starship_class: string;
}

interface Vehicle {
  name: string;
  model: string;
  manufacturer: string;
  cost_in_credits: string;
  length: string;
  max_atmosphering_speed: string;
  crew: string
  passengers: string;
  cargo_capacity: string;
  consumables: string;
  vehicle_class: string;
}

interface Specie {
  name: string;
  classification: string;
  designation: string;
  average_height: string;
  skin_colors: string;
  hair_colors: string;
  eye_colors: string
  average_lifespan: string;
  language: string;
}


