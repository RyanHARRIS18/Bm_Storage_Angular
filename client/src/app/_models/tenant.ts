import { ContractFile } from './contract';

export interface Tenant {
    id: number;
    userName: string;
    age: number;
    knownAs: string;
    gateCode: number;
    firstName: string;
    lastName: string;
    streetAddress: string;
    city: string;
    state: string;
    zip: number;
    created: Date;
    lastActive: Date;
    contractFiles: ContractFile[];
  }
  
