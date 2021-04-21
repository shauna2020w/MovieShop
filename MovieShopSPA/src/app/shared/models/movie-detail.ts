export interface MovieDetails {
    id: number;
    title: string;
    tagline?: string;
    runtime: number;
    createdDate: Date;
    genres?: any;
    overview?: string;
    releaseDate?: Date;
    boxOffice?: number;
    budget?: number;
    posterUrl: string;
    rating?: any;
    castCollection?: any[];
}
