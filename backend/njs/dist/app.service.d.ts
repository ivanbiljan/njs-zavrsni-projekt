import User from "./infrastructure/data/User";
export declare class AppService {
    private user;
    constructor(user: typeof User);
    getHello(): string;
}
