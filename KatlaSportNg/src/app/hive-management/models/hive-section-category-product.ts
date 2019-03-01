export class HiveSectionCategoryProduct {
    constructor(
        public id: number,
        public productId: number,
        public name: string,
        public code: string,
        public quantity: number,        
        public isDeleted: boolean,
        public isApproved: boolean
    ) { }
}
