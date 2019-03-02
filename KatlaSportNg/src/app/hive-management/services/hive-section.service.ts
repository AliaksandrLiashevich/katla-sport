import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { HiveSection } from '../models/hive-section';
import { HiveSectionListItem } from '../models/hive-section-list-item';
import { HiveSectionCategory } from '../models/hive-section-categorie';
import { HiveSectionCategoryProduct } from '../models/hive-section-category-product';
import { HiveSectionCategoryAvailableProduct } from '../models/hive-section-category-available-product';

@Injectable({
  providedIn: 'root'
})
export class HiveSectionService {
  private url = environment.apiUrl + 'api/sections/';

  constructor(private http: HttpClient) { }

  getHiveSections(): Observable<Array<HiveSectionListItem>> {
    return this.http.get<Array<HiveSectionListItem>>(this.url);
  }

  getHiveSection(hiveSectionId: number): Observable<HiveSection> {
    return this.http.get<HiveSection>(`${this.url}${hiveSectionId}`);
  }

  getHiveSectionCategories(hiveSectionId: number): Observable<Array<HiveSectionCategory>>{
    return this.http.get<Array<HiveSectionCategory>>(`${this.url}${hiveSectionId}/categories`);
  }

  getHiveSectionCategoryProducts(hiveSectionId: number, categoryId: number): Observable<Array<HiveSectionCategoryProduct>>{
    return this.http.get<Array<HiveSectionCategoryProduct>>(`${this.url}${hiveSectionId}/category/${categoryId}/products`);
  }

  getHiveSectionAvailableCategoryProducts(hiveSectionId: number, categoryId: number): Observable<Array<HiveSectionCategoryAvailableProduct>>{
    return this.http.get<Array<HiveSectionCategoryAvailableProduct>>(`${this.url}${hiveSectionId}/category/${categoryId}/avaliableProducts`);
  }

  addHiveSection(hiveSection: HiveSection): Observable<HiveSection> {
    return this.http.post<HiveSection>(this.url, hiveSection);
  }

  addHiveSectionCategoryProduct(product: HiveSectionCategoryAvailableProduct): Observable<HiveSectionCategoryAvailableProduct> {
    return this.http.post<HiveSectionCategoryAvailableProduct>(`${environment.apiUrl}api/product`, product);
  }

  updateHiveSection(hiveSection: HiveSection): Observable<Object> {
    return this.http.put(`${this.url}${hiveSection.id}`, hiveSection);
  }

  deleteHiveSection(hiveSectionId: number): Observable<Object> {
    return this.http.delete(`${this.url}${hiveSectionId}`);
  }

  setHiveSectionStatus(hiveSectionId: number, deletedStatus: boolean): Observable<Object> {
    return this.http.put(`${this.url}${hiveSectionId}/status/${deletedStatus}`, null);
  }

  setHiveSectionCategoryProductApprovedStatus(hiveSectionCategoryProductId: number, deletedStatus: boolean): Observable<Object> {
    return this.http.put(`${environment.apiUrl}api/product/${hiveSectionCategoryProductId}/approvedStatus/${deletedStatus}`, null);
  }

  setHiveSectionCategoryProductDeletedStatus(hiveSectionCategoryProductId: number, deletedStatus: boolean): Observable<Object> {
    return this.http.put(`${environment.apiUrl}api/product/${hiveSectionCategoryProductId}/deletedStatus/${deletedStatus}`, null);
  }

  deleteHiveSectionCategoryProduct(hiveSectionCategoryProductId: number): Observable<Object> {
    return this.http.delete(`${environment.apiUrl}api/product/${hiveSectionCategoryProductId}`);
  }
}
