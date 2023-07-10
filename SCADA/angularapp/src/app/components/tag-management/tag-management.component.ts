import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { AnalogInputCreateDTO, AnalogOutputCreateDTO, DigitalInputCreateDTO, DigitalOutputCreateDTO } from 'src/app/models/createTags';
import { AnalogInput, AnalogOutput, DigitalInput, DigitalOutput } from 'src/app/models/tags';

@Component({
  selector: 'app-tag-management',
  templateUrl: './tag-management.component.html',
  styleUrls: ['./tag-management.component.css']
})
export class TagManagementComponent {

  showAddTagPopup: boolean = false;
  showUpdateOutputValuePopup: boolean = false;
  tagType: string = '';

  digitalInputs: DigitalInput[] = [];
  digitalOutputs: DigitalOutput[] = [];
  analogInputs: AnalogInput[] = [];
  analogOutputs: AnalogOutput[] = [];

  constructor(private http: HttpClient) {
    this.loadDigitalInputs();
    this.loadDigitalOutputs();
    this.loadAnalogInputs();
    this.loadAnalogOutputs();
  }

  loadDigitalInputs() {
    this.http.get<DigitalInput[]>('/api/Tag/DigitalInputs').subscribe(data => {
      this.digitalInputs = data;
    });
  }

  loadDigitalOutputs() {
    this.http.get<DigitalOutput[]>('/api/Tag/DigitalOutputs').subscribe(data => {
      this.digitalOutputs = data;
    });
  }

  loadAnalogInputs() {
    this.http.get<AnalogInput[]>('/api/Tag/AnalogInputs').subscribe(data => {
      this.analogInputs = data;
    });
  }

  loadAnalogOutputs() {
    this.http.get<AnalogOutput[]>('/api/Tag/AnalogOutputs').subscribe(data => {
      this.analogOutputs = data;
    });
  }



  openAddTagPopup(tagType: string) {
    this.tagType = tagType;
    this.showAddTagPopup = true;
  }

  closeAddTagPopup() {
    this.showAddTagPopup = false;
  }

  openUpdateOutputValuePopup(tagType: string) {
    this.tagType = tagType;
    this.showUpdateOutputValuePopup = true;
  }

  closeUpdateOutputValuePopup() {
    this.showUpdateOutputValuePopup = false;
  }


  deleteDigitalInput(id: number) {
    this.http.delete(`/api/Tag/DigitalInputs/${id}`).subscribe(() => {
      this.loadDigitalInputs();
    });
  }

  deleteDigitalOutput(id: number) {
    this.http.delete(`/api/Tag/DigitalOutputs/${id}`).subscribe(() => {
      this.loadDigitalOutputs();
    });
  }

  deleteAnalogInput(id: number) {
    this.http.delete(`/api/Tag/AnalogInputs/${id}`).subscribe(() => {
      this.loadAnalogInputs();
    });
  }

  deleteAnalogOutput(id: number) {
    this.http.delete(`/api/Tag/AnalogOutputs/${id}`).subscribe(() => {
      this.loadAnalogOutputs();
    });
  }


  turnDigitalInput(id: number) {
    const digitalInput = this.digitalInputs.find(d => d.id === id);
    if (!digitalInput) {
      return;
    }
  
    const isScanning = !digitalInput.isScanning;
    const scan: any = {
      isScanning: isScanning
    };
    this.http.put(`/api/Tag/DigitalInputs/${id}/IsScanning`, scan).subscribe(() => {
      digitalInput.isScanning = isScanning;
    });
  }

  turnAnalogInput(id: number) {
    const analogInput = this.analogInputs.find(d => d.id === id);
    if (!analogInput) {
      return;
    }
  
    const isScanning = !analogInput.isScanning;
    const scan: any = {
      isScanning: isScanning
    };
    this.http.put(`/api/Tag/AnalogInputs/${id}/IsScanning`, scan).subscribe(() => {
      analogInput.isScanning = isScanning;
    });
  }



  analogInputForm: AnalogInputCreateDTO = {
    description: '',
    scanTime: 0,
    lowLimit: 0,
    highLimit: 0,
    unit: ''
  };
  analogOutputForm: AnalogOutputCreateDTO = {
    description: '',
    initialValue: 0,
    lowLimit: 0,
    highLimit: 0,
    unit: ''
  };
  digitalInputForm: DigitalInputCreateDTO = {
    description: '',
    scanTime: 0
  };
  digitalOutputForm: DigitalOutputCreateDTO = {
    description: '',
    initialValue: false
  };

  createAnalogInput() {
    const url = '/api/Tag/AnalogInputs';
    this.http.post<AnalogInput>(url, this.analogInputForm).subscribe((response) => {
      console.log('Analog Input tag created successfully:', response);
      this.analogInputs.push(response); // Update the analogInputs list with the new tag
      this.showAddTagPopup = false;
    }, (error) => {
      console.error('Error creating Analog Input tag:', error);
    });
    // Reset the form inputs
    this.analogInputForm = {
      description: '',
      scanTime: 0,
      lowLimit: 0,
      highLimit: 0,
      unit: ''
    };
  }

  createAnalogOutput() {
    const url = '/api/Tag/AnalogOutputs';
    this.http.post<AnalogOutput>(url, this.analogOutputForm).subscribe((response) => {
      console.log('Analog Output tag created successfully:', response);
      this.analogOutputs.push(response); // Update the analogOutputs list with the new tag
      this.showAddTagPopup = false;
    }, (error) => {
      console.error('Error creating Analog Output tag:', error);
    });
    // Reset the form inputs
    this.analogOutputForm = {
      description: '',
      initialValue: 0,
      lowLimit: 0,
      highLimit: 0,
      unit: ''
    };
  }

  createDigitalInput() {
    const url = '/api/Tag/DigitalInputs';
    this.http.post<DigitalInput>(url, this.digitalInputForm).subscribe((response) => {
      console.log('Digital Input tag created successfully:', response);
      this.digitalInputs.push(response); // Update the digitalInputs list with the new tag
      this.showAddTagPopup = false;
    }, (error) => {
      console.error('Error creating Digital Input tag:', error);
    });
    // Reset the form inputs
    this.digitalInputForm = {
      description: '',
      scanTime: 0
    };
  }

  createDigitalOutput() {
    const url = '/api/Tag/DigitalOutputs';
    this.http.post<DigitalOutput>(url, this.digitalOutputForm).subscribe((response) => {
      console.log('Digital Output tag created successfully:', response);
      this.digitalOutputs.push(response); // Update the digitalOutputs list with the new tag
      this.showAddTagPopup = false;
    }, (error) => {
      console.error('Error creating Digital Output tag:', error);
    });
    // Reset the form inputs
    this.digitalOutputForm = {
      description: '',
      initialValue: false
    };
  }
}
